using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TgSharp.TL;
using TgSharp.TL.Account;
using TgSharp.TL.Auth;
using TgSharp.TL.Contacts;
using TgSharp.TL.Help;
using TgSharp.TL.Messages;
using TgSharp.TL.Upload;
using TgSharp.NETCore.Auth;
using TgSharp.NETCore.Exceptions;
using TgSharp.NETCore.MTProto.Crypto;
using TgSharp.NETCore.Network;
using TgSharp.NETCore.Network.Exceptions;
using TgSharp.NETCore.Utils;
using TLAuthorization = TgSharp.TL.Auth.TLAuthorization;
using System.Globalization;

namespace TgSharp.NETCore
{
    public class TelegramClient : IDisposable
    {
        private const int SIZE_FOR_HASH = 256;

        private MtProtoSender sender;
        private TcpTransport transport;
        private readonly string apiHash;
        private readonly int apiId;
        private readonly string sessionUserId;
        private readonly ISessionStore store;
        private List<TLDcOption> dcOptions;
        private readonly TcpClientConnectionHandler handler;
        private readonly DataCenterIPVersion dcIpVersion;

        public Session Session { get; private set; }

        /// <summary>
        /// Creates a new TelegramClient
        /// </summary>
        /// <param name="apiId">The API ID provided by Telegram. Get one at https://my.telegram.org </param>
        /// <param name="apiHash">The API Hash provided by Telegram. Get one at https://my.telegram.org </param>
        /// <param name="store">An ISessionStore object that will handle the session</param>
        /// <param name="sessionUserId">The name of the session that tracks login info about this TelegramClient connection</param>
        /// <param name="handler">A delegate to invoke when a connection is needed and that will return a TcpClient that will be used to connect</param>
        /// <param name="dcIpVersion">Indicates the preferred IpAddress version to use to connect to a Telegram server</param>
        public TelegramClient(int apiId, string apiHash,
            DataCenterIPVersion dcIpVersion = DataCenterIPVersion.Default,
            ISessionStore store = null,
            string sessionUserId = "session",
            TcpClientConnectionHandler handler = null
            )
        {
            if (apiId == default(int))
                throw new MissingApiConfigurationException("API_ID");
            if (string.IsNullOrEmpty(apiHash))
                throw new MissingApiConfigurationException("API_HASH");

            if (store == null)
                store = new FileSessionStore();
            this.store = store;

            this.apiHash = apiHash;
            this.apiId = apiId;
            this.handler = handler;
            this.dcIpVersion = dcIpVersion;

            this.sessionUserId = sessionUserId;
        }

        public async Task ConnectAsync (string langCode = "en", string langPack = "en", string version = "1.0.0", TLAbsInputClientProxy proxy = null, CancellationToken token = default (CancellationToken))
        {
            await ConnectInternalAsync(false, langCode, langPack, version, proxy, token);
        }

        private async Task ConnectInternalAsync (bool reconnect = false, string langCode = "en", string langPack = "en", string version = "1.0.0", TLAbsInputClientProxy proxy = null, CancellationToken token = default (CancellationToken))
        {
            token.ThrowIfCancellationRequested();

            Session = SessionFactory.TryLoadOrCreateNew (store, sessionUserId);
            transport = new TcpTransport (Session.DataCenter.Address, Session.DataCenter.Port, this.handler);

            if (Session.AuthKey == null || reconnect)
            {
                var result = await Authenticator.DoAuthentication(transport, token).ConfigureAwait(false);
                Session.AuthKey = result.AuthKey;
                Session.TimeOffset = result.TimeOffset;
            }

            sender = new MtProtoSender(transport, store, Session);

            //set-up layer 121
            TLRequestGetConfig config = new TLRequestGetConfig();
            TLRequestInitConnection<TLRequestGetConfig> request = new TLRequestInitConnection<TLRequestGetConfig>()
            {
                ApiId = apiId,
                AppVersion = version,                
                DeviceModel = "PC",
                LangCode = langCode,
                Query = config,
                SystemVersion = "Win 10.0",
                SystemLangCode = CultureInfo.CurrentCulture.TwoLetterISOLanguageName,
                Proxy = proxy,
                //Params = new TLDataJSON()
                LangPack = langPack
            };
            var invokewithLayer = new TLRequestInvokeWithLayer<TLRequestInitConnection<TLRequestGetConfig>>() { Layer = 121, Query = request };
            await sender.Send(invokewithLayer, token).ConfigureAwait(false);
            await sender.Receive(invokewithLayer, token).ConfigureAwait(false);

            dcOptions = ((TLConfig)invokewithLayer.Response.Response.Response).DcOptions.Cast<TLDcOption>().ToList();
        }

        private async Task ReconnectToDcAsync(int dcId, CancellationToken token = default(CancellationToken))
        {
            token.ThrowIfCancellationRequested();

            if (dcOptions == null || !dcOptions.Any())
                throw new InvalidOperationException($"Can't reconnect. Establish initial connection first.");

            TLExportedAuthorization exported = null;
            if (Session.TLUser != null)
            {
                TLRequestExportAuthorization exportAuthorization = new TLRequestExportAuthorization() { DcId = dcId };
                exported = await SendRequestAsync<TLExportedAuthorization>(exportAuthorization, token).ConfigureAwait(false);
            }

            IEnumerable<TLDcOption> dcs;
            if (dcIpVersion == DataCenterIPVersion.OnlyIPv6)
                dcs = dcOptions.Where(d => d.Id == dcId && d.Ipv6); // selects only ipv6 addresses 	
            else if (dcIpVersion == DataCenterIPVersion.OnlyIPv4)
                dcs = dcOptions.Where(d => d.Id == dcId && !d.Ipv6); // selects only ipv4 addresses
            else
                dcs = dcOptions.Where(d => d.Id == dcId); // any

            dcs = dcs.Where (d => !d.MediaOnly);

            TLDcOption dc;
            if (dcIpVersion != DataCenterIPVersion.Default)
            {
                if (!dcs.Any())
                    throw new Exception($"Telegram server didn't provide us with any IPAddress that matches your preferences. If you chose OnlyIPvX, try switch to PreferIPvX instead.");
                dcs = dcs.OrderBy(d => d.Ipv6);
                dc = dcIpVersion == DataCenterIPVersion.PreferIPv4 ? dcs.First() : dcs.Last(); // ipv4 addresses are at the beginning of the list because it was ordered
            }
            else
                dc = dcs.First();
            
            var dataCenter = new DataCenter (dcId, dc.IpAddress, dc.Port);
            Session.DataCenter = dataCenter;
            this.store.Save (Session);

            await ConnectInternalAsync(true, token: token).ConfigureAwait(false);

            if (Session.TLUser != null)
            {
                TLRequestImportAuthorization importAuthorization = new TLRequestImportAuthorization() { Id = exported.Id, Bytes = exported.Bytes };
                var imported = await SendRequestAsync<TLAuthorization>(importAuthorization, token).ConfigureAwait(false);
                OnUserAuthenticated((TLUser)imported.User);
            }
        }

        private async Task RequestWithDcMigration(TLMethod request, CancellationToken token = default(CancellationToken))
        {
            if (sender == null)
                throw new InvalidOperationException("Not connected!");

            var completed = false;
            while (!completed)
            {
                try
                {
                    await sender.Send(request, token).ConfigureAwait(false);
                    await sender.Receive(request, token).ConfigureAwait(false);
                    completed = true;
                }
                catch (DataCenterMigrationException e)
                {
                    if (Session.DataCenter.DataCenterId.HasValue &&
                        Session.DataCenter.DataCenterId.Value == e.DC)
                    {
                        throw new Exception($"Telegram server replied requesting a migration to DataCenter {e.DC} when this connection was already using this DataCenter", e);
                    }

                    await ReconnectToDcAsync(e.DC, token).ConfigureAwait(false);
                    // prepare the request for another try
                    request.ConfirmReceived = false;
                }
            }
        }

        #region Authintication

        public bool IsUserAuthorized()
        {
            return Session.TLUser != null;
        }

        public async Task<TLAbsSentCode> SendCodeRequestAsync(string phoneNumber, CancellationToken token = default(CancellationToken))
        {
            if (String.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentNullException(nameof(phoneNumber));

            var request = new TLRequestSendCode() { PhoneNumber = phoneNumber, ApiId = apiId, ApiHash = apiHash, Settings = new TLCodeSettings {  } };

            await RequestWithDcMigration(request, token).ConfigureAwait(false);

            return request.Response;
        }

        public async Task<TLUser> MakeAuthAsync(string phoneNumber, string phoneCodeHash, string code, string firstName = "", string lastName = "", CancellationToken token = default(CancellationToken))
        {
            if (String.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentNullException(nameof(phoneNumber));

            if (String.IsNullOrWhiteSpace(phoneCodeHash))
                throw new ArgumentNullException(nameof(phoneCodeHash));

            if (String.IsNullOrWhiteSpace(code))
                throw new ArgumentNullException(nameof(code));

            var request = new TLRequestSignIn() { PhoneNumber = phoneNumber, PhoneCodeHash = phoneCodeHash, PhoneCode = code };

            await RequestWithDcMigration(request, token).ConfigureAwait(false);

            if (request.Response is TLAuthorization)
            {
                OnUserAuthenticated(((TLUser)((TLAuthorization)request.Response).User));
                return ((TLUser)((TLAuthorization)request.Response).User);
            }
            else
            {
                var signUpRequest = new TLRequestSignUp() { PhoneNumber = phoneNumber, PhoneCodeHash = phoneCodeHash, FirstName = firstName, LastName = lastName };
                await RequestWithDcMigration(signUpRequest, token).ConfigureAwait(false);
                OnUserAuthenticated((TLUser)((TLAuthorization)signUpRequest.Response).User);
                return (TLUser)((TLAuthorization)signUpRequest.Response).User;
            }
        }

        public async Task<TLPassword> GetPasswordSetting(CancellationToken token = default(CancellationToken))
        {
            var request = new TLRequestGetPassword();

            await RequestWithDcMigration(request, token).ConfigureAwait(false);

            return (TLPassword)request.Response;
        }

        public async Task<TLUser> MakeAuthWithPasswordAsync(TLPassword password, string password_str, CancellationToken token = default(CancellationToken))
        {
            token.ThrowIfCancellationRequested();

            var request = new TLRequestCheckPassword() { Password = computeCheck(password, password_str) };

            await RequestWithDcMigration(request, token).ConfigureAwait(false);

            OnUserAuthenticated((TLUser)((TLAuthorization)request.Response).User);

            return (TLUser)((TLAuthorization)request.Response).User;
        }

        private byte[] pbkdf2sha512(byte[] password, byte[] salt, int iterations)
        {
            // @ts-ignore should probably add pollifier
            return GetPbkdf2Bytes(password, salt, iterations, 64, HashAlgorithmName.SHA512);
        }

        /**
         *
         * @param algo {constructors.PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow}
         * @param password
         * @returns {Buffer|*}
         */
        private byte[] ComputeHash(TLPasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow algo, string password)
        {
            byte[] hash1 = Helpers.Sha256(algo.Salt1.Concat(Encoding.UTF8.GetBytes(password).Concat(algo.Salt1)).ToArray());
            byte[] hash2 = Helpers.Sha256(algo.Salt2.Concat(hash1.Concat(algo.Salt2)).ToArray());
            byte[] hash3 = pbkdf2sha512(hash2, algo.Salt1, 100000);
            return Helpers.Sha256(algo.Salt2.Concat(hash3.Concat(algo.Salt2).ToArray()).ToArray());
        }

        /**
         *
         * @param algo {constructors.PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow}
         * @param password
         */
        private byte[] ComputeDigest(TLPasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow algo, string password)
        {
            try
            {
                checkPrimeAndGood(algo.P, algo.G);
            }
            catch
            {
                throw new Exception("bad p/g in password");
            }

            BigInteger value = BigInteger.ValueOf(algo.G).ModPow(
                new BigInteger(ComputeHash(algo, password)),
                new BigInteger(algo.P));
            return bigNumForHash(value);
        }

        private static byte[] GetPbkdf2Bytes(byte[] password, byte[] salt, int iterations, int outputBytes, HashAlgorithmName hashName)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, hashName);
            return pbkdf2.GetBytes(outputBytes);
        }

        /**
         *
         * @param request {constructors.account.Password}
         * @param password {string}
         */
        private TLInputCheckPasswordSRP computeCheck(TLPassword request, string password)
        {
            var algo = (TLPasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow)request.CurrentAlgo;
            if (!(algo is TLPasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow)) {
                throw new Exception($"Unsupported password algorithm {algo.GetType().Name}");
            }

            byte[] srp_B = request.SrpB;
            long srpId = request.SrpId;
            if (srp_B == null || srpId == 0)
            {
                throw new Exception($"Undefined srp_b {request}");
            }

            var pwHash = ComputeHash(algo, password);
            BigInteger p = new BigInteger(algo.P);
            int g = algo.G;
            BigInteger B = new BigInteger(srp_B);
            try
            {
                checkPrimeAndGood(algo.P, g);
            }
            catch
            {
                throw new Exception("bad /g in password");
            }

            if (!isGoodLarge(B, p))
            {
                throw new Exception("bad b in check");
            }
            BigInteger x = new BigInteger(pwHash);
            byte[] pForHash = numBytesForHash(algo.P);
            byte[] gForHash = bigNumForHash(BigInteger.ValueOf(g));
            byte[] bForHash = numBytesForHash(srp_B);
            BigInteger gX = BigInteger.ValueOf(g).ModPow(x, p);
            BigInteger k = new BigInteger(Helpers.Sha256(pForHash.Concat(gForHash).ToArray()));
            var kgX = bigIntMod(k.Multiply(gX), p);

            Tuple<BigInteger, byte[], BigInteger> generateAndCheckRandom()
            {
                const int randomSize = 256;
                // eslint-disable-next-line no-constant-condition
                while (true)
                {
                    byte[] random = Helpers.GenerateRandomBytes(randomSize); // generateRandomBytes
                    BigInteger a = new BigInteger(random); // readBigIntFromBuffer
                    BigInteger A = (BigInteger.ValueOf(g).ModPow(a, p));
                    if (isGoodModExpFirst(A, p))
                    {
                        byte[] aForHash = bigNumForHash(A);
                        BigInteger u = new BigInteger(Helpers.Sha256(aForHash.Concat(bForHash).ToArray()));
                        if (u.CompareTo(BigInteger.Zero) == 1)
                        {
                            return new Tuple<BigInteger, byte[], BigInteger>(a, aForHash, u);
                        }
                    }
                }
            };

            Tuple<BigInteger, byte[], BigInteger> res = generateAndCheckRandom();
            var gB = bigIntMod(B.Subtract(kgX), p);
            if (!isGoodModExpFirst(gB, p))
            {
                throw new Exception("bad gB");
            }

            BigInteger ux = res.Item3.Multiply(x);
            BigInteger aUx = res.Item1.Add(ux);
            BigInteger S = gB.ModPow(aUx, p);
            byte[] K = Helpers.Sha256(bigNumForHash(S));
            byte[] pSha = Helpers.Sha256(pForHash);
            byte[] gSha = Helpers.Sha256(gForHash);
            byte[] salt1Sha = Helpers.Sha256(algo.Salt1);
            byte[] salt2Sha = Helpers.Sha256(algo.Salt2);

            byte[] M1 = Helpers.Sha256(Xor(pSha, gSha).Concat(
                    salt1Sha.Concat(
                    salt2Sha.Concat(
                    res.Item2.Concat(
                    bForHash.Concat(
                    K))))).ToArray());


            return new TLInputCheckPasswordSRP() {
                SrpId = S.LongValue,
                A = res.Item2,
                M1 = M1
            };
        }

        private bool isGoodModExpFirst(BigInteger modexp, BigInteger prime)
        {
            BigInteger diff = prime.Subtract(modexp);

            const int minDiffBitsCount = 2048 - 64;
            const int maxModExpSize = 256;

            return !(diff.CompareTo(BigInteger.Zero) == -1) || diff.BitLength < minDiffBitsCount ||
                modexp.BitLength < minDiffBitsCount ||
                Math.Floor(((double)modexp.BitLength + 7) / 8) > maxModExpSize;
        }

        private void checkPrimeAndGood(byte[] primeBytes, int g)
        {
            byte[] goodPrime = {
                0xC7, 0x1C, 0xAE, 0xB9, 0xC6, 0xB1, 0xC9, 0x04, 0x8E, 0x6C, 0x52, 0x2F, 0x70, 0xF1, 0x3F, 0x73,
                0x98, 0x0D, 0x40, 0x23, 0x8E, 0x3E, 0x21, 0xC1, 0x49, 0x34, 0xD0, 0x37, 0x56, 0x3D, 0x93, 0x0F,
                0x48, 0x19, 0x8A, 0x0A, 0xA7, 0xC1, 0x40, 0x58, 0x22, 0x94, 0x93, 0xD2, 0x25, 0x30, 0xF4, 0xDB,
                0xFA, 0x33, 0x6F, 0x6E, 0x0A, 0xC9, 0x25, 0x13, 0x95, 0x43, 0xAE, 0xD4, 0x4C, 0xCE, 0x7C, 0x37,
                0x20, 0xFD, 0x51, 0xF6, 0x94, 0x58, 0x70, 0x5A, 0xC6, 0x8C, 0xD4, 0xFE, 0x6B, 0x6B, 0x13, 0xAB,
                0xDC, 0x97, 0x46, 0x51, 0x29, 0x69, 0x32, 0x84, 0x54, 0xF1, 0x8F, 0xAF, 0x8C, 0x59, 0x5F, 0x64,
                0x24, 0x77, 0xFE, 0x96, 0xBB, 0x2A, 0x94, 0x1D, 0x5B, 0xCD, 0x1D, 0x4A, 0xC8, 0xCC, 0x49, 0x88,
                0x07, 0x08, 0xFA, 0x9B, 0x37, 0x8E, 0x3C, 0x4F, 0x3A, 0x90, 0x60, 0xBE, 0xE6, 0x7C, 0xF9, 0xA4,
                0xA4, 0xA6, 0x95, 0x81, 0x10, 0x51, 0x90, 0x7E, 0x16, 0x27, 0x53, 0xB5, 0x6B, 0x0F, 0x6B, 0x41,
                0x0D, 0xBA, 0x74, 0xD8, 0xA8, 0x4B, 0x2A, 0x14, 0xB3, 0x14, 0x4E, 0x0E, 0xF1, 0x28, 0x47, 0x54,
                0xFD, 0x17, 0xED, 0x95, 0x0D, 0x59, 0x65, 0xB4, 0xB9, 0xDD, 0x46, 0x58, 0x2D, 0xB1, 0x17, 0x8D,
                0x16, 0x9C, 0x6B, 0xC4, 0x65, 0xB0, 0xD6, 0xFF, 0x9C, 0xA3, 0x92, 0x8F, 0xEF, 0x5B, 0x9A, 0xE4,
                0xE4, 0x18, 0xFC, 0x15, 0xE8, 0x3E, 0xBE, 0xA0, 0xF8, 0x7F, 0xA9, 0xFF, 0x5E, 0xED, 0x70, 0x05,
                0x0D, 0xED, 0x28, 0x49, 0xF4, 0x7B, 0xF9, 0x59, 0xD9, 0x56, 0x85, 0x0C, 0xE9, 0x29, 0x85, 0x1F,
                0x0D, 0x81, 0x15, 0xF6, 0x35, 0xB1, 0x05, 0xEE, 0x2E, 0x4E, 0x15, 0xD0, 0x4B, 0x24, 0x54, 0xBF,
                0x6F, 0x4F, 0xAD, 0xF0, 0x34, 0xB1, 0x04, 0x03, 0x11, 0x9C, 0xD8, 0xE3, 0xB9, 0x2F, 0xCC, 0x5B,
            };
            if (goodPrime.Equals(primeBytes))
            {
                if (g == 2 || g == 3 || g == 5 || g == 7)
                {
                    return; // It's good
                }
            }
            throw new Exception("Changing passwords unsupported");
    //checkPrimeAndGoodCheck(readBigIntFromBuffer(primeBytes, false), g)
}

        /**
         *
         * @param number{BigInteger}
         * @param p{BigInteger}
         * @returns {boolean}
         */
        private bool isGoodLarge(BigInteger number, BigInteger p)
        {
            return number.CompareTo(BigInteger.Zero) == 1 && p.Subtract(number).CompareTo(BigInteger.Zero) == 1;
        }

        /**
         *
         * @param number {Buffer}
         * @returns {Buffer}
         */
        private byte[] numBytesForHash(byte[] number)
        {
            // Use it as array
            List<byte> x = new List<byte>(SIZE_FOR_HASH - number.Length);
            x.AddRange(number);
            return x.ToArray();
        }

        /**
         *
         * @param g {bigInt}
         * @returns {Buffer}
         */
        private byte[] bigNumForHash(BigInteger g)
        {
            return g.ToByteArrayUnsigned();
        }

        private byte[] Xor(byte[] a, byte[] b)
        {
            int length = Math.Min(a.Length, b.Length);

            for (int i = 0; i < length; i++)
            {
                a[i] = (byte)(a[i] ^ b[i]);
            }

            return a;
        }

        private BigInteger bigIntMod(BigInteger n, BigInteger m)
        {
            return n.Remainder(m).Add(m).Remainder(m);
        }

        #endregion

        public async Task<T> SendRequestAsync<T>(TLMethod methodToExecute, CancellationToken token = default(CancellationToken))
        {
            await RequestWithDcMigration(methodToExecute, token).ConfigureAwait(false);

            var result = methodToExecute.GetType().GetProperty("Response").GetValue(methodToExecute);

            return (T)result;
        }

        internal async Task<T> SendAuthenticatedRequestAsync<T>(TLMethod methodToExecute, CancellationToken token = default(CancellationToken))
        {
            if (!IsUserAuthorized())
                throw new InvalidOperationException("Authorize user first!");

            return await SendRequestAsync<T>(methodToExecute, token)
                .ConfigureAwait(false);
        }

        public async Task<TLUser> UpdateUsernameAsync(string username, CancellationToken token = default(CancellationToken))
        {
            var req = new TLRequestUpdateUsername { Username = username };

            return await SendAuthenticatedRequestAsync<TLUser>(req, token)
                .ConfigureAwait(false);
        }

        public async Task<bool> CheckUsernameAsync(string username, CancellationToken token = default(CancellationToken))
        {
            var req = new TLRequestCheckUsername { Username = username };

            return await SendAuthenticatedRequestAsync<bool>(req, token)
                .ConfigureAwait(false);
        }

        #region Contacts

        public async Task<TLImportedContacts> ImportContactsAsync(IEnumerable<TLAbsInputContact> contacts, CancellationToken token = default(CancellationToken))
        {
            var req = new TLRequestImportContacts { Contacts = new TLVector<TLAbsInputContact>(contacts) };

            return await SendAuthenticatedRequestAsync<TLImportedContacts>(req, token)
                .ConfigureAwait(false);
        }

        public async Task<bool> DeleteContactsAsync(IReadOnlyList<TLAbsInputUser> users, CancellationToken token = default(CancellationToken))
        {
            var req = new TLRequestDeleteContacts { Id = new TLVector<TLAbsInputUser>(users) };

            return await SendAuthenticatedRequestAsync<bool>(req, token)
                .ConfigureAwait(false);
        }

        public async Task<TLContacts> GetContactsAsync(CancellationToken token = default(CancellationToken))
        {
            var req = new TLRequestGetContacts() { Hash = 0 };

            return await SendAuthenticatedRequestAsync<TLContacts>(req, token)
                .ConfigureAwait(false);
        }

        #endregion


        #region Messaging

        public async Task<TLAbsUpdates> SendMessageAsync(TLAbsInputPeer peer, string message, DateTime? scheduleDate = null, bool slient = false, CancellationToken token = default(CancellationToken))
        {
            return await SendAuthenticatedRequestAsync<TLAbsUpdates>(
                new TLRequestSendMessage()
                {
                    Peer = peer,
                    Message = message,
                    ScheduleDate = (int)(scheduleDate?.Subtract(new DateTime(1970, 1, 1))).Value.TotalMinutes,
                    Silent = slient,
                    RandomId = Helpers.GenerateRandomLong()
                }, token)
                .ConfigureAwait(false);
        }

        public async Task<Boolean> SendTypingAsync(TLAbsInputPeer peer, CancellationToken token = default(CancellationToken))
        {
            var req = new TLRequestSetTyping()
            {
                Action = new TLSendMessageTypingAction(),
                Peer = peer
            };
            return await SendAuthenticatedRequestAsync<Boolean>(req, token)
                .ConfigureAwait(false);
        }

        public async Task<TLAbsUpdates> SendUploadedPhoto(TLAbsInputPeer peer, TLAbsInputFile file, string message, CancellationToken token = default(CancellationToken))
        {
            if (String.IsNullOrEmpty(message)) {
                throw new ArgumentNullException (nameof (message));
            }

            return await SendAuthenticatedRequestAsync<TLAbsUpdates>(new TLRequestSendMedia()
            {
                RandomId = Helpers.GenerateRandomLong(),
                Background = false,
                ClearDraft = false,
                Message = message,
                Media = new TLInputMediaUploadedPhoto() { File = file },
                Peer = peer
            }, token)
                .ConfigureAwait(false);
        }

        public async Task<TLAbsUpdates> SendPoll(
            TLAbsInputPeer peer, TLPoll poll, string solution, CancellationToken token = default(CancellationToken))
        {
            return await SendAuthenticatedRequestAsync<TLAbsUpdates>(new TLRequestSendMedia()
            {
                RandomId = Helpers.GenerateRandomLong(),
                Background = false,
                ClearDraft = false,
                Media = new TLInputMediaPoll()
                {
                    Poll = poll,
                    Solution = solution
                },
                Peer = peer
            }, token)
                .ConfigureAwait(false);
        }

        #endregion


        public async Task<TLAbsUpdates> SendUploadedDocument(
            TLAbsInputPeer peer, TLAbsInputFile file, string mimeType, TLVector<TLAbsDocumentAttribute> attributes, CancellationToken token = default(CancellationToken))
        {
            return await SendAuthenticatedRequestAsync<TLAbsUpdates>(new TLRequestSendMedia()
            {
                RandomId = Helpers.GenerateRandomLong(),
                Background = false,
                ClearDraft = false,
                Media = new TLInputMediaUploadedDocument()
                {
                    File = file,
                    MimeType = mimeType,
                    Attributes = attributes
                },
                Peer = peer
            }, token)
                .ConfigureAwait(false);
        }

        #region Updates

        public async Task<TLAbsDialogs> GetUserDialogsAsync(int offsetDate = 0, int offsetId = 0, TLAbsInputPeer offsetPeer = null, int limit = 100, CancellationToken token = default(CancellationToken))
        {
            if (offsetPeer == null)
                offsetPeer = new TLInputPeerSelf();

            var req = new TLRequestGetDialogs()
            {
                OffsetDate = offsetDate,
                OffsetId = offsetId,
                OffsetPeer = offsetPeer,
                Limit = limit
            };
            return await SendAuthenticatedRequestAsync<TLAbsDialogs>(req, token)
                .ConfigureAwait(false);
        }

        #endregion

        public async Task<TLFile> GetFile(TLAbsInputFileLocation location, int filePartSize, int offset = 0, CancellationToken token = default(CancellationToken))
        {
            TLFile result = await SendAuthenticatedRequestAsync<TLFile>(new TLRequestGetFile
            {
                Location = location,
                Limit = filePartSize,
                Offset = offset
            }, token)
                .ConfigureAwait(false);
            return result;
        }

        public async Task SendPingAsync(CancellationToken token = default(CancellationToken))
        {
            await sender.SendPingAsync(token)
                .ConfigureAwait(false);
        }

        public async Task<TLAbsMessages> GetHistoryAsync(TLAbsInputPeer peer, int offsetId = 0, int offsetDate = 0, int addOffset = 0, int limit = 100, int maxId = 0, int minId = 0, CancellationToken token = default(CancellationToken))
        {
            var req = new TLRequestGetHistory()
            {
                Peer = peer,
                OffsetId = offsetId,
                OffsetDate = offsetDate,
                AddOffset = addOffset,
                Limit = limit,
                MaxId = maxId,
                MinId = minId
            };
            return await SendAuthenticatedRequestAsync<TLAbsMessages>(req, token)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Serch user or chat. API: contacts.search#11f812d8 q:string limit:int = contacts.Found;
        /// </summary>
        /// <param name="q">User or chat name</param>
        /// <param name="limit">Max result count</param>
        /// <returns></returns>
        public async Task<TLFound> SearchUserAsync(string q, int limit = 10, CancellationToken token = default(CancellationToken))
        {
            var r = new TL.Contacts.TLRequestSearch
            {
                Q = q,
                Limit = limit
            };

            return await SendAuthenticatedRequestAsync<TLFound>(r, token)
                .ConfigureAwait(false);
        }

        private void OnUserAuthenticated(TLUser TLUser)
        {
            Session.TLUser = TLUser;
            Session.SessionExpires = int.MaxValue;

            this.store.Save (Session);
        }

        public bool IsConnected
        {
            get
            {
                if (transport == null)
                    return false;
                return transport.IsConnected;
            }
        }

        public void Dispose()
        {
            if (transport != null)
            {
                transport.Dispose();
                transport = null;
            }
        }
    }
}

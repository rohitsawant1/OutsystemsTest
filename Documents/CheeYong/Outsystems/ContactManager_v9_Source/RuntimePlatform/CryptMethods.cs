using System;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.Cryptography;
using OutSystems.RuntimeCommon.Cryptography.Insecure;

#if RUNTIMEPLATFORM
using OutSystems.HubEdition.RuntimePlatform;

#endif

internal class CryptMethods {

    internal static string MD5HashWithPrivateSalt(string str) {
        var toReturn = MD5PasswordHelper.HexDeriveUsingUTF16(str, SharedKeys.PrivateSalt());
        OSTrace.Debug("MD5HashWithPrivateSalt returned:" + toReturn);
        return toReturn;
    }
}

#if TESTS
}
#endif

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Trillium.EllipticCurve;

namespace Trillium.Utilities
{
    internal class CreateSignatureUtility
    {
        public static string CreateSignature(string message, string privKey)
        {
            BigInteger b1 = BigInteger.Parse(privKey, NumberStyles.AllowHexSpecifier);//converts hex private key into big int.
            PrivateKey privateKey = new PrivateKey("secp256k1", b1);

            var pubKey = privateKey.publicKey();
            var pubKeyFormatted = "04" + ByteToHex(pubKey.toString());

            var signature = CreateSignatureService(message, privateKey, pubKeyFormatted);

            return signature;
        }

        public static string CreateSignatureService(string message, PrivateKey PrivKey, string pubKey)
        {

            Signature signature = Ecdsa.sign(message, PrivKey);
            var sigBase64 = signature.toBase64();
            var pubKeyEncoded = Base58Utility.Base58Encode(HexByteUtility.HexToByte(pubKey.Remove(0, 2)));
            var sigScript = sigBase64 + "." + pubKeyEncoded;

            //validate new signature
            var sigScriptArray = sigScript.Split('.', 2);
            var pubKeyDecoded = HexByteUtility.ByteToHex(Base58Utility.Base58Decode(sigScriptArray[1]));
            var pubKeyByte = HexByteUtility.HexToByte(pubKeyDecoded);
            var publicKey = PublicKey.fromString(pubKeyByte);
            var verifyCheck = Ecdsa.verify(message, Signature.fromBase64(sigScriptArray[0]), publicKey);

            if (verifyCheck != true)
                return "ERROR";
            return sigScript;
        }

        public static string ByteToHex(byte[] pubkey)
        {
            return Convert.ToHexString(pubkey).ToLower();
        }
    }
}

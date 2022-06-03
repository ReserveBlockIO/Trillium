using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Trillium.EllipticCurve;
using System.Security.Cryptography;

namespace Trillium.Utilities
{
    internal class ValidateSignatureUtility
    {
		public static byte AddressPrefix = 0x3C; //address prefix 'R'

		public static bool VerifySignature(string address, string message, string sigScript)
        {
            var sigScriptArray = sigScript.Split('.', 2);
            var pubKeyDecoded = HexByteUtility.ByteToHex(Base58Utility.Base58Decode(sigScriptArray[1]));
            var pubKeyByte = HexByteUtility.HexToByte(pubKeyDecoded);
            var publicKey = PublicKey.fromString(pubKeyByte);

            var _PublicKey = "04" + ByteToHex(publicKey.toString());
            var _Address = GetHumanAddress(_PublicKey);

            if (address != _Address)
            {
                return false;
            }

            return Ecdsa.verify(message, Signature.fromBase64(sigScriptArray[0]), publicKey);
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

        public static string GetHumanAddress(string pubKeyHash)
        {
            byte[] PubKey = HexToByte(pubKeyHash);
            byte[] PubKeySha = Sha256(PubKey);
            byte[] PubKeyShaRIPE = RipeMD160(PubKeySha);
            byte[] PreHashWNetwork = AppendReserveBlockNetwork(PubKeyShaRIPE, AddressPrefix);//This will create Address starting with 'R'
            byte[] PublicHash = Sha256(PreHashWNetwork);
            byte[] PublicHashHash = Sha256(PublicHash);
            byte[] Address = ConcatAddress(PreHashWNetwork, PublicHashHash);
            return Base58Encode(Address); //Returns human readable address starting with an 'R'
        }

		public static string ByteToHex(byte[] pubkey)
		{
			return Convert.ToHexString(pubkey).ToLower();
		}
		public static byte[] HexToByte(string HexString)
		{
			if (HexString.Length % 2 != 0)
				throw new Exception("Invalid HEX");
			byte[] retArray = new byte[HexString.Length / 2];
			for (int i = 0; i < retArray.Length; ++i)
			{
				retArray[i] = byte.Parse(HexString.Substring(i * 2, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
			}
			return retArray;
		}
		public static byte[] Sha256(byte[] array)
		{
			SHA256Managed hashstring = new SHA256Managed();
			return hashstring.ComputeHash(array);
		}

		public static byte[] RipeMD160(byte[] array)
		{
			RIPEMD160Managed hashstring = new RIPEMD160Managed();
			return hashstring.ComputeHash(array);
		}

		public static byte[] AppendReserveBlockNetwork(byte[] RipeHash, byte Network)
		{
			byte[] extended = new byte[RipeHash.Length + 1];
			extended[0] = (byte)Network;
			Array.Copy(RipeHash, 0, extended, 1, RipeHash.Length);
			return extended;
		}
		public static byte[] ConcatAddress(byte[] RipeHash, byte[] Checksum)
		{
			byte[] ret = new byte[RipeHash.Length + 4];
			Array.Copy(RipeHash, ret, RipeHash.Length);
			Array.Copy(Checksum, 0, ret, RipeHash.Length, 4);
			return ret;
		}

		public static string Base58Encode(byte[] array)
		{
			const string ALPHABET = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
			string retString = string.Empty;
			BigInteger encodeSize = ALPHABET.Length;
			BigInteger arrayToInt = 0;

			for (int i = 0; i < array.Length; ++i)
			{
				arrayToInt = arrayToInt * 256 + array[i];
			}

			while (arrayToInt > 0)
			{
				int rem = (int)(arrayToInt % encodeSize);
				arrayToInt /= encodeSize;
				retString = ALPHABET[rem] + retString;
			}

			for (int i = 0; i < array.Length && array[i] == 0; ++i)
				retString = ALPHABET[0] + retString;
			return retString;
		}
	}
}

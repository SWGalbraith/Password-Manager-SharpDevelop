using PasswordManager.CommonUtils;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.Encryption
{
    public static class Crypto
    {
        private static string cryptoHexKey = null;
        private const string HEX_PREFIX = "HEX";

        static Crypto()
        {
            cryptoHexKey = CryptoHelper.UnRandomiseData(
                UserDataHelper.GetCryptoKey().Replace(HEX_PREFIX, String.Empty));
        }

        public static string Encrypt(string data)
        {
            string encryptedData = null;
            bool isEncryptionValid = true;
            string dataLength = Convert.ToString(data.Length);

            while (dataLength.Length < 5)
            {
                dataLength = dataLength.Insert(0, "0");
            }

            // Make sure that the encrypted string is valid using this loop
            do
            {
                isEncryptionValid = true;

                byte[] encryptedDataBytes = null;

                using (Aes aesCrypto = Aes.Create())
                {
                    aesCrypto.Key = CryptoHelper.HexToBinary(cryptoHexKey);

                    try
                    {
                        encryptedDataBytes = EncryptToBytes(data, aesCrypto.Key, aesCrypto.IV);

                        // Hash the encrypted bytes, and then pad the Hashed Initialisation Value 
                        // and the length of the original data onto the encrypted string for later decryption
                        encryptedData =
                            CryptoHelper.BinaryToHex(encryptedDataBytes) +
                            CryptoHelper.BinaryToHex(aesCrypto.IV).TrimStart(HEX_PREFIX.ToCharArray()) +
                            dataLength;
                    }
                    catch (Exception e)
                    {
                        throw new InvalidOperationException(
                            "Crypto.Encrypt() - Problem encrypting data! - " + e.Message);
                    }
                }

                try
                {
                    Decrypt(CryptoHelper.RandomiseData(encryptedData));
                }
                catch (Exception)
                {
                    isEncryptionValid = false;
                }
            }
            while (!isEncryptionValid);

            return HEX_PREFIX + CryptoHelper.RandomiseData(encryptedData);
        }

        public static string Decrypt(string data)
        {
            string decryptedData = null;

            data = data.Replace(HEX_PREFIX, String.Empty);

            data = CryptoHelper.UnRandomiseData(data);

            // Retrieve and Remove the original Data Length from the encrypted data
            int dataLength = ExtractDataLengthFromEncryptedString(data);
            data = data.Substring(0, data.Length - 5);

            // Retrieve and Remove the Initialisation Value from the encrypted data
            byte[] initialisationVector = ExtractIVFromEncryptedData(data);
            string ivToTrim = CryptoHelper.BinaryToHex(initialisationVector).TrimStart(HEX_PREFIX.ToCharArray());
            data = data.Remove(data.IndexOf(ivToTrim));

            byte[] key = CryptoHelper.HexToBinary(cryptoHexKey);            
            byte[] encryptedData = CryptoHelper.HexToBinary(data);

            try
            {
                decryptedData = DecryptFromBytes(encryptedData, key, initialisationVector);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(
                    "Crypto.Decrypt() - Problem decrypting data! - " + e.Message);
            }

            // Return the decrypted string with padding trimmed out
            return decryptedData.Substring(0, dataLength);
        }

        private static byte[] EncryptToBytes(string data, byte[] key, byte[] initialisationVector)
        {
            ValidateInput(data, key, initialisationVector);

            byte[] encrypted = null;
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            using (Aes aesCrypto = new AesManaged())
            {
                aesCrypto.Padding = PaddingMode.Zeros;
                aesCrypto.KeySize = 128;
                aesCrypto.Key = key;
                aesCrypto.IV = initialisationVector;

                ICryptoTransform encryptor = aesCrypto.CreateEncryptor(aesCrypto.Key, aesCrypto.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(dataBytes, 0, dataBytes.Length);
                    }

                    encrypted = ms.ToArray();
                }
            }

            return encrypted;

        }

        private static string DecryptFromBytes(byte[] encryptedData, byte[] key, byte[] initialisationVector)
        {
            ValidateInput(encryptedData, key, initialisationVector);

            byte[] decryptedData = null;

            using (Aes aesCrypto = new AesManaged())
            {
                aesCrypto.Padding = PaddingMode.Zeros;
                aesCrypto.KeySize = 128;
                aesCrypto.Key = key;
                aesCrypto.IV = initialisationVector;

                ICryptoTransform decryptor = aesCrypto.CreateDecryptor(aesCrypto.Key, aesCrypto.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedData, 0, encryptedData.Length);
                    }

                    decryptedData = ms.ToArray();
                }
            }

            return Encoding.UTF8.GetString(decryptedData);
        }

        private static byte[] ExtractIVFromEncryptedData(string encryptedData)
        {
            int ivLength = 32;
            string hexInitialisationVector = 
                HEX_PREFIX.ToString() + encryptedData.Substring(encryptedData.Length - ivLength);

            return CryptoHelper.HexToBinary(hexInitialisationVector);
        }

        private static int ExtractDataLengthFromEncryptedString(string encryptedData)
        {
            string dataLength = encryptedData.Substring(encryptedData.Length - 5);

            while (dataLength.StartsWith("0"))
            {
                dataLength = dataLength.TrimStart('0');
            }

            return Convert.ToInt32(dataLength);
        }

        private static void ValidateInput(string data, byte[] key, byte[] initialisationVector)
        {
            const string ARGUMENT_NULL_EXCEPTION_MESSAGE = 
                "Crypto.ValidateInput() - The passed {0} was invalid!";

            if (data == null || data.Length <= 0)
            {
                throw new ArgumentNullException(String.Format(ARGUMENT_NULL_EXCEPTION_MESSAGE, "Data"));
            }

            ValidateKey(key, initialisationVector);
        }

        private static void ValidateInput(byte[] data, byte[] key, byte[] initialisationVector)
        {
            const string ARGUMENT_NULL_EXCEPTION_MESSAGE =
                "Crypto.ValidateInput() - The passed{0} was invalid!";

            if (data == null || data.Length <= 0)
            {
                throw new ArgumentNullException(String.Format(ARGUMENT_NULL_EXCEPTION_MESSAGE, "Data"));
            }

            ValidateKey(key, initialisationVector);
        }

        private static void ValidateKey(byte[] key, byte[] initialisationVector)
        {
            const string ARGUMENT_NULL_EXCEPTION_MESSAGE =
                "Crypto.ValidateInput() - The passed {0} was invalid!";

            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException(String.Format(ARGUMENT_NULL_EXCEPTION_MESSAGE, "Key"));
            }
            if (initialisationVector == null || initialisationVector.Length <= 0)
            {
                throw new ArgumentNullException(
                    String.Format(ARGUMENT_NULL_EXCEPTION_MESSAGE, "Initialisation Vector"));
            }
        }

    }
}

using System;
using System.Security.Cryptography;

namespace PasswordManager.Encryption
{
    public static class CryptoHelper
    {
        private static readonly char[] HEXCHARS = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        private const string HEX_PREFIX = "HEX";

        public static string CreateNewCryptoKey()
        {
            byte[] cryptoBytes = null;
            
            using (Aes aesCrypto = Aes.Create())
            {
                cryptoBytes = aesCrypto.Key;
            }

            return HEX_PREFIX + RandomiseData(BinaryToHex(cryptoBytes));
        }

        public static string BinaryToHex(byte[] data)
        {
            int dataLength = data.Length * 2;
            char[] convertedCharacter = new char[dataLength];

            for (int i = 0; i < dataLength; i += 2)
            {
                convertedCharacter[i + 0] = HEXCHARS[data[i / 2] >> 4];
                convertedCharacter[i + 1] = HEXCHARS[data[i / 2] & 0xF];
            }

            return HEX_PREFIX + new string(convertedCharacter);
        }

        public static byte[] HexToBinary(string data)
        {
            const string EXCEPTION_MESSAGE = "Invalid Hex String Len={0} ({1}) Should be '{2}' prefixed.";

            int hexDataLength = data.Length;

            if (hexDataLength < 3 || data.Substring(0, 3) != HEX_PREFIX || ((hexDataLength - 3) % 2) != 0)
            {
                throw new InvalidOperationException(
                    string.Format(EXCEPTION_MESSAGE, hexDataLength, data, HEX_PREFIX));
            }

            char[] input = data.ToCharArray(3, hexDataLength - 3);
            hexDataLength -= 3;

            byte[] binaryData = new Byte[hexDataLength / 2];

            for (int i = 0; i < hexDataLength; i += 2)
            {
                binaryData[i / 2] = (byte)((HexToBinary(input[i], true) << 4) | HexToBinary(input[i + 1], true));
            }

            return binaryData;
        }

        private static int HexToBinary(char character, bool throwException)
        {
            const string EXCEPTION_MESSAGE = "Invalid Hex Digit [{0}]";

            if (character >= '0' && character <= '9')
            {
                return character - '0';
            }
            if (character >= 'A' && character <= 'F')
            {
                return 10 + character - 'A';
            }
            if (character >= 'a' && character <= 'z')
            {
                return 10 + character - 'a';
            }

            if (throwException)
            {
                throw new InvalidOperationException(string.Format(EXCEPTION_MESSAGE, character));
            }

            return -1;
        }

        public static string RandomiseData(string data)
        {
            int size = data.Length;
            int key = GetRandomisationKey(size);
            char[] chars = data.ToCharArray();
            var exchanges = GetRandomisationExchanges(size, key);

            for (int i = size - 1; i > 0; i--)
            {
                int n = exchanges[size - 1 - i];
                char tmp = chars[i];
                chars[i] = chars[n];
                chars[n] = tmp;
            }

            return new string(chars);
        }

        public static string UnRandomiseData(string randomisedData)
        {
            int size = randomisedData.Length;
            int key = GetRandomisationKey(size);
            char[] chars = randomisedData.ToCharArray();
            var exchanges = GetRandomisationExchanges(size, key);

            for (int i = 1; i < size; i++)
            {
                int n = exchanges[size - i - 1];
                char tmp = chars[i];
                chars[i] = chars[n];
                chars[n] = tmp;
            }

            return new string(chars);
        }

        private static int[] GetRandomisationExchanges(int size, int key)
        {
            int[] exchanges = new int[size - 1];
            var rand = new Random(key);

            for (int i = size - 1; i > 0; i--)
            {
                int n = rand.Next(i + 1);
                exchanges[size - 1 - i] = n;
            }

            return exchanges;
        }

        private static int GetRandomisationKey(int number)
        {
            string key = number.ToString();

            foreach (char c in Environment.UserName)
            {
                string currentCharacter = c.ToString();
                int isNumber = 0;

                Int32.TryParse(currentCharacter, out isNumber);

                if (isNumber > 0)
                {
                    key += currentCharacter;
                }
            }

            return Int32.Parse(key);
        }
    }
}

using System.Security.Cryptography;
using System.Text;

namespace DokkanIdentifierConvertor
{
    internal class Security
    {
        private string aesKey = ""; //can't share the key on github

        public string DecryptIdentifier(string identifier)
        {
            return DecryptStringFromBytes(identifier,aesKey);
        }

        private string DecryptStringFromBytes(string cipherText, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.Mode = CipherMode.ECB;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherTextBytes, 0, cipherTextBytes.Length);

                string plaintext = Encoding.UTF8.GetString(decryptedBytes);

                return plaintext;
            }
        }
    }
}

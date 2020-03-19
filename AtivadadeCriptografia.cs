using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace trabalho_criptografia
{
    public class AtivadadeCriptografia
    {
        static string ORIGINAL_FILE_NAME = "originalFile.txt";
        static string ENCRYPTED_FILE_NAME = "encryptedData.crypt";

        public static void Execute(int mode)
        {
            // Create an instance of the RSA algorithm class  
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            if (mode == 1)
            {
                // Get the public key
                string publicKey = rsa.ToXmlString(false); // false to get the public key

                // Call the encryptText method   
                EncryptFile(publicKey, ORIGINAL_FILE_NAME, ENCRYPTED_FILE_NAME);
            }
            else if (mode == 2)
            {
                string privateKey = rsa.ToXmlString(true); // true to get the private key   

                // Call the decryptData method and print the result on the screen   
                Console.WriteLine("Conteúdo Descriptografado: {0}", DecryptFile(privateKey, ENCRYPTED_FILE_NAME));
            }
            else {
                throw new Exception("Opção informada não existe.");
            }
        }

        /// <summary>
        /// Create a method to encrypt a text and save it to a specific file using a RSA algorithm public key   
        /// </summary>
        private static void EncryptFile(string publicKey, string originalFile, string encryptedFile)
        {
            // Convert the text to an array of bytes   
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = File.ReadAllBytes(originalFile);

            // Create a byte array to store the encrypted data in it   
            byte[] encryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Set the rsa pulic key   
                rsa.FromXmlString(publicKey);

                // Encrypt the data and store it in the encyptedData Array   
                encryptedData = rsa.Encrypt(dataToEncrypt, false);
            }
            // Save the encypted data array into a file   
            File.WriteAllBytes(encryptedFile, encryptedData);

            Console.WriteLine("O arquivo foi criptografado -> {0}\\{1}", Directory.GetCurrentDirectory(), ENCRYPTED_FILE_NAME);
        }

        /// <summary>
        /// Method to decrypt the data withing a specific file using a RSA algorithm private key   
        /// </summary>
        private static string DecryptFile(string privateKey, string encryptedFile)
        {
            // read the encrypted bytes from the file   
            byte[] dataToDecrypt = File.ReadAllBytes(encryptedFile);

            // Create an array to store the decrypted data in it   
            byte[] decryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Set the private key of the algorithm   
                rsa.FromXmlString(privateKey);
                decryptedData = rsa.Decrypt(dataToDecrypt, true);
            }

            // Get the string value from the decryptedData byte array   
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            return byteConverter.GetString(decryptedData);
        }
    }
}
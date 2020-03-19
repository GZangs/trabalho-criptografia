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

        // Create an instance of the RSA algorithm class  
        static RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

        public static void Execute(int mode)
        {
            string publicKey = rsa.ToXmlString(false); // false to get the public key
            string privateKey = rsa.ToXmlString(true); // true to get the private key   

            if (mode == 1)
            {
                Console.WriteLine("Conteúdo do arquivo original: {0}", File.ReadAllText(ORIGINAL_FILE_NAME));
                // Call the encryptText method   
                EncryptFile(publicKey);
            }
            else if (mode == 2)
            {
                // Call the decryptData method and print the result on the screen   
                Console.WriteLine("Conteúdo descriptografado: {0}", DecryptFile(privateKey));
            }
            else {
                throw new Exception("Opção informada não existe.");
            }
        }

        /// <summary>
        /// Create a method to encrypt a text and save it to a specific file using a RSA algorithm public key   
        /// </summary>
        private static void EncryptFile(string publicKey)
        {
            // Convert the text to an array of bytes   
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(File.ReadAllText(ORIGINAL_FILE_NAME));  
            
            // Create a byte array to store the encrypted data in it   
            byte[] encryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Set the rsa pulic key   
                rsa.FromXmlString(publicKey);

                // Encrypt the data and store it in the encyptedData Array   
                encryptedData = rsa.Encrypt(dataToEncrypt, true);
            }
            // Save the encypted data array into a file   
            File.WriteAllBytes(ENCRYPTED_FILE_NAME, encryptedData);

            Console.WriteLine("");
            Console.WriteLine("O arquivo foi criptografado -> {0}\\{1}", Directory.GetCurrentDirectory(), ENCRYPTED_FILE_NAME);
        }

        /// <summary>
        /// Method to decrypt the data withing a specific file using a RSA algorithm private key   
        /// </summary>
        private static string DecryptFile(string privateKey)
        {
            // read the encrypted bytes from the file   
            byte[] dataToDecrypt = File.ReadAllBytes(ENCRYPTED_FILE_NAME);

            // Create an array to store the decrypted data in it   
            byte[] decryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Set the private key of the algorithm   
                rsa.FromXmlString(privateKey);
                decryptedData = rsa.Decrypt(dataToDecrypt, true);
            }

            // Get the string value from the decryptedData byte array   
            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
using System;
using System.IO;
using System.Security.Cryptography;

namespace trabalho_criptografia
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keep = true;
            while (keep)
            {
                Console.WriteLine("===========================================================");
                Console.WriteLine("Você deseja criptografar o arquivo ou descriptografar?");
                Console.WriteLine("");
                Console.WriteLine("1 -> Criptografar | 2 -> Descriptografar | 3 -> Sair");
                Console.WriteLine("===========================================================");

                try
                {
                    var mode = Int32.Parse(Console.ReadLine());

                    if (mode == 3) return;
                    AtivadadeCriptografia.Execute(mode);
                }
                catch (FileNotFoundException)
                {
                    Console.Clear();
                    Console.WriteLine("Erro: Você precisa criptografar o arquivo antes! \r\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: {0}", ex);
                }
            }
        }
    }
}

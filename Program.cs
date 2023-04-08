using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            a1:
            Console.WriteLine("\nВыберите режим:");
            Console.WriteLine("1 - Шифрование текста с помощью частотного анализа");
            Console.WriteLine("2 - Шифрование текста с помощью ключа");
            Console.WriteLine("3 - Шифрование текста с ASCII");
            Console.WriteLine("4 - Дешифрование текста с помощью частотного анализа");
            Console.WriteLine("5 - Дешифрование текста с помощью ключа");

            string mode = Console.ReadLine();
            switch (mode)
            {
                case "1":
                {
                    Console.Write("Введите текст для шифрования: ");
                    string message = Console.ReadLine();
                    if (message.Length < 1)
                    {
                        Console.WriteLine("Ошибка. Пожалуйста, введите текст");
                    }
                    else
                    {
                        Console.Write("Введите ключ (строка без повторяющихся символов): ");
                        string key = Console.ReadLine();
                        if (key.Length < 1)
                        {
                            Console.WriteLine("Ошибка. Пожалуйста, введите ключ");
                        }
                        else
                        {
                            string encryptedMessage = EncryptByFrequencyAnalysis(message, key);
                            Console.Write("Зашифрованный текст: ");
                            Console.WriteLine(encryptedMessage);
                        }
                    }
                    goto a1;
                }
                case "2":
                {
                    Console.Write("Введите текст для шифрования: ");
                    string message = Console.ReadLine();
                    if (message.Length < 1)
                    {
                        Console.WriteLine("Ошибка. Пожалуйста, введите текст");
                    }
                    else
                    {
                        Console.Write("Введите ключ (строка без повторяющихся символов): ");
                        string key = Console.ReadLine();
                        if (key.Length < 1)
                        {
                            Console.WriteLine("Ошибка. Пожалуйста, введите ключ");
                        }
                        else
                        {
                            string encryptedMessage = EncryptByKey(message, key);
                            Console.Write("Зашифрованный текст: ");
                            Console.WriteLine(encryptedMessage);
                        }
                    }

                    goto a1;
                }
                case "3":
                {
                    Console.Write("Введите текст для шифрования: ");
                    string message = Console.ReadLine();
                    if (message.Length < 1)
                    {
                        Console.WriteLine("Ошибка. Пожалуйста, введите текст");
                    }
                    else
                    {
                        Console.Write("Введите целое число: ");
                        int key = 0;
                        int.TryParse(Console.ReadLine(), out key);
                        if (key == 0)
                        {
                            Console.WriteLine("Ошибка. Пожалуйста, введите целое число");
                        }
                        else
                        {
                            string encryptedMessage = EncryptByShift(message, key);
                            Console.Write("Зашифрованный текст: ");
                            Console.WriteLine(encryptedMessage);
                        }
                    }
                    
                    goto a1;
                }
                case "4":
                {
                    Console.Write("Введите текст для дешифрования: ");
                    string encryptedMessage = Console.ReadLine();
                    if (encryptedMessage.Length < 1)
                    {
                        Console.WriteLine("Ошибка. Пожалуйста, введите текст");
                    }
                    else
                    {
                        Console.Write("Введите ключ (строка без повторяющихся символов): ");
                        string key = Console.ReadLine();
                        if (key.Length < 1)
                        {
                            Console.WriteLine("Ошибка. Пожалуйста, введите ключ");
                        }
                        else
                        {
                            string decryptedMessage = DecryptByFrequencyAnalysis(encryptedMessage, key);
                            Console.Write("Расшифрованный текст: ");
                            Console.WriteLine(decryptedMessage);
                        }
                    }
                   
                    goto a1;
                }
                case "5":
                {
                    Console.Write("Введите текст для дешифрования: ");
                    string encryptedMessage = Console.ReadLine();
                    if (encryptedMessage.Length < 1)
                    {
                        Console.WriteLine("Ошибка. Пожалуйста, введите текст");
                    }
                    else
                    {
                        Console.Write("Введите ключ (строка без повторяющихся символов): ");
                        string key = Console.ReadLine();
                        if (key.Length < 1)
                        {
                            Console.WriteLine("Ошибка. Пожалуйста, введите ключ");
                        }
                        else
                        {
                            string decryptedMessage = DecryptByKey(encryptedMessage, key);
                            Console.Write("Расшифрованный текст: ");
                            Console.WriteLine(decryptedMessage);
                        }
                    }
                    goto a1;
                }
                default:
                    Console.WriteLine("Некорректный режим.");
                    goto a1;
            }
            
        }
        
        
        static string EncryptByFrequencyAnalysis(string message, string key)
        {
            
                try
                {
                    var charCodes = new Dictionary<char, string>();
                    for (int i = 0; i < key.Length; i++)
                    {
                        charCodes.Add(key[i], i.ToString());
                    }

                    var encryptedChars = new List<string>();
                    foreach (char c in message)
                    {
                        if (charCodes.TryGetValue(c, out string code))
                        {
                            encryptedChars.Add(code);
                        }
                        else
                        {
                            encryptedChars.Add(c.ToString());
                        }
                    }

                    return string.Join(" ", encryptedChars);
                }
                catch 
                {
                    Console.WriteLine("Не используйте два одинаковых символа для ключ-кода!");
                }
                
            return null;
        }

        static string EncryptByKey(string message, string key)
        {
            try
            {
                var charCodes = new Dictionary<char, char>();
                for (int i = 0; i < key.Length; i++)
                {
                    charCodes.Add(key[i], (char)(i + 65));
                }

                var encryptedChars = new List<char>();
                foreach (char c in message)
                {
                    if (charCodes.TryGetValue(c, out char code))
                    {
                        encryptedChars.Add(code);
                    }
                    else
                    {
                        encryptedChars.Add(c);
                    }
                }

                return new string(encryptedChars.ToArray());
            }
            catch 
            {
                Console.WriteLine("Не используйте два одинаковых символа для ключ-кода!");
                 
            }

            return null;
        }
        
        static string EncryptByShift(string message, int key)
        {
            Random rnd = new Random();
            string encryptedMessage = "";

            for (int i = 0; i < message.Length; i++)
            {
                char encryptedChar = (char)(message[i] + key);
                
                encryptedMessage += encryptedChar;
                
                if ((i + 1) % 4 == 0)
                {
                    int numExtraChars = rnd.Next(1, 4);
                    for (int j = 0; j < numExtraChars; j++)
                    {
                        char extraChar = (char)rnd.Next(32, 127);
                        encryptedMessage += extraChar;
                    }
                }
            }

            return encryptedMessage;
        }
        
        

        static string DecryptByFrequencyAnalysis(string encryptedMessage, string key)
        {
            var charCodes = new Dictionary<string, char>();
            for (int i = 0; i < key.Length; i++)
            {
                charCodes.Add(i.ToString(), key[i]);
            }

            var encryptedChars = encryptedMessage.Split();
            var decryptedChars = new List<string>();
            foreach (var c in encryptedChars)
            {
                if (charCodes.TryGetValue(c, out char symbol))
                {
                    decryptedChars.Add(symbol.ToString());
                }
                else
                {
                    decryptedChars.Add(c);
                }
            }

            return string.Join("", decryptedChars);
        }



        static string DecryptByKey(string encryptedMessage, string key)
        {
            var charCodes = new Dictionary<char, char>();
            for (int i = 0; i < key.Length; i++)
            {
                charCodes.Add((char)(i + 65), key[i]);
            }

            var decryptedChars = new List<char>();
            foreach (char c in encryptedMessage)
            {
                if (charCodes.TryGetValue(c, out char code))
                {
                    decryptedChars.Add(code);
                }
                else
                {
                    decryptedChars.Add(c);
                }
            }

            return new string(decryptedChars.ToArray());
        }
    }
}

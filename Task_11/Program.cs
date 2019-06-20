using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_11
{
    class Program
    {
            public static String CaesarCipher(String cipherText, Int32 key)
            {
                String alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                String cipherTextLow = cipherText.ToLower();
                Char[] sourceText = new Char[cipherTextLow.Length];
                Int32 j = 0;

                for (Int32 i = 0; i < cipherTextLow.Length; i++)
                {
                    if (!Char.IsLetter(cipherTextLow[i]))
                        sourceText[i] = cipherTextLow[i];
                    else
                    {
                        sourceText[i] = '|';
                        while (sourceText[i] == '|')
                        {
                            if (cipherTextLow[i] == alphabet[j])
                            {
                                try
                                {
                                    sourceText[i] = alphabet[j + key];
                                }
                                catch
                                {
                                    sourceText[i] = alphabet[(j + key) - 33];
                                }
                            }
                            j++;
                        }
                        j = 0;
                    }
                }

                return new String(sourceText);
            }

            static void Main(string[] args)
            {
                Console.WriteLine("<<< задача 11 >>>");
                menu();

                Console.ReadKey();
            }
        static void menu()
        {
            Console.WriteLine(@"1. Зашифровать
2. Расшифровать
3. Выход");
            int answer = 0;
            answer = int.Parse(Console.ReadLine());
            switch(answer)
            {
                case 1:
                    shifr();
                    break;
                case 2:
                    unshifr();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                    
                
            }
        }

        static void shifr()
        {
            Console.Write("Введите слово для шифрования: ");
            string read = Console.ReadLine();

            Console.Write("Введите коэффициент шифрования: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Результат: ");
            Console.WriteLine(CaesarCipher(read, n));

            menu();
        }
        static void unshifr()
        {
            Console.Write("Введите слово для расфрования: ");
            string read = Console.ReadLine();

            Console.Write("Введите коэффициент расфрования: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Результат: ");
            Console.WriteLine(CaesarUnCipher(read, n));

            menu();
        }
        public static String CaesarUnCipher(String cipherText, Int32 key)
        {
            String alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            String cipherTextLow = cipherText.ToLower();
            Char[] sourceText = new Char[cipherTextLow.Length];
            Int32 j = 0;

            for (Int32 i = 0; i < cipherTextLow.Length; i++)
            {
                if (!Char.IsLetter(cipherTextLow[i]))
                    sourceText[i] = cipherTextLow[i];
                else
                {
                    sourceText[i] = '|';
                    while (sourceText[i] == '|')
                    {
                        if (cipherTextLow[i] == alphabet[j])
                        {
                            try
                            {
                                sourceText[i] = alphabet[j - key];
                            }
                            catch
                            {
                                sourceText[i] = alphabet[(j - key) + 33];
                            }
                        }
                        j++;
                    }
                    j = 0;
                }
            }

            return new String(sourceText);
        }

    }
    }


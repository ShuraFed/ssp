using System;
using System.Linq;

namespace stonepaper
{
    class Program
    {
        static void Main(string[] args)
        {
            bool readyToPlay=true;
            int length=args.Length;
            if (length<3)                                              
            {
                Console.WriteLine("You need to input at least 3 elements");
                readyToPlay = false;
            }
            if (length%2==0)
            {
                Console.WriteLine("The number of elements should be odd");
                readyToPlay = false;
            }
            if (args.Distinct().Count()!=args.Length)
            {
                Console.WriteLine("Every element should be unique. For example: a b c");
                readyToPlay = false;
            }

            if (readyToPlay)
            {
                while (true)
                {
                    Console.WriteLine("\n   +++ New Game +++\n");
                    string key=KeyGenerator.GenerateKey();
                    int pc=KeyGenerator.ChooseTurn(length);
                    Console.WriteLine("HMAC: "+KeyGenerator.GenerateHMAC(pc,key)+"\n");

                Menu:
                    Console.WriteLine("Avaliable moves:\n");
                    for (int i = 0; i < length; i++)
                    {
                        Console.WriteLine($"{i + 1} - {args[i]}\n");
                    }
                    Console.WriteLine("0 - Exit\n");
                    Console.WriteLine("? - Help\n");
                    Console.Write("Choose your move: ");
                    string s = Console.ReadLine();
                    
                    try
                    {
                        int a=int.Parse(s);

                        if (a == 0)
                        {
                            break;
                        }
                        else if (a > 0 && a <= length)
                        {
                            int player = a - 1;
                            Console.WriteLine($"\nYour move: {args[player]}");
                            Console.WriteLine($"\nComputer move: {args[pc]}");
                            Console.WriteLine("\nResult: "+Winner.Show(args, player, pc));
                            Console.WriteLine("\nHMAC key: " + key);
                            Console.WriteLine();
                        }
                        else goto Menu;
                    }
                    catch (Exception)
                    {
                        if (s=="?")
                        {
                            HelpTable.Show(args);
                        }
                        goto Menu;
                    }
                }
            }
        }
    }
}

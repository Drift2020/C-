using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SerchFW
{
    class Start
    {
        static void Print()
        {

            Console.WriteLine("1. Search File\n2. Print File\nEsc. Exit");
        }
        static void Main()
        {
            SerchFW File_Search = new SerchFW();
            Print();
            ConsoleKey key;
            do
            {
                Print();
                ConsoleKeyInfo info = Console.ReadKey();
                key = info.Key;
                try
                {
                    switch (key)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();

                            Console.Write("Please, enter Path: ");
                            string path = Console.ReadLine();
                            Console.Write("Please, enter Mask: ");
                            string mask = Console.ReadLine();
                           

                            File_Search.AddParams(path, mask);
                            File_Search.SearchFiles();
                            Print();
                            break;
                        case ConsoleKey.D2:
                            int numbr=0, key1;

                            do
                            {
                               
                               Console.WriteLine();
                               Console.WriteLine("1. Next     2. Beak    3. Delite    4. Exit");

                                key1 = Int32.Parse(Console.ReadLine());
                                
                                switch (key1)
                                {
                                    case 1:
                                        Console.Clear();
                                        numbr += 50;
                                        File_Search.Print(numbr);
                                        
                                        break;
                                    case 2:
                                        Console.Clear();
                                        if ((numbr - 50) >= 0)
                                        {
                                            numbr -= 50;
                                            File_Search.Print(numbr);                                          
                                        }
                                        break;
                                    case 3:
                                        
                                        File_Search.Delete();
                                        Console.Clear();
                                        File_Search.Print(numbr);
                                        break;
                                }
                            } while (key1!=4);
                            
                            break;
                      

                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e + "\n");
                    Print();
                }
            } while (key != ConsoleKey.Escape);
        }
    }
}

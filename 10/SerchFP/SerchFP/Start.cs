using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SerchFP
{
    class Start
    {
        static void Print()
        {
           
            Console.WriteLine("1. Search File\nEsc. Exit");
        }
        static void Main()
        {
            FileSearch File_Search = new FileSearch();
            Print();
            ConsoleKey key;
            do
            {
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
                            Console.Write("Please, enter date to: ");
                            DateTime timeTo = DateTime.Parse(Console.ReadLine());
                            Console.Write("Please, enter date past: ");
                            DateTime timePast = DateTime.Parse(Console.ReadLine());

                            File_Search.AddParams(path,mask,timeTo,timePast);
                            File_Search.SearchFiles();
                            Print();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e+"\n");
                    Print();
                }
            } while (key != ConsoleKey.Escape);
        }
    }
}

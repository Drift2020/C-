using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_7
{
    class Start
    {

        void Print_Start_Menu()
        {
            Console.WriteLine("1. Start simulator\nEsc. Exit");
        }

        void Menu(ConsoleKey key)
        {
            switch(key)
            {
                case ConsoleKey.LeftArrow:
                   
                    break;
                case ConsoleKey.RightArrow:
                 
                    break;
                case ConsoleKey.UpArrow:
                 
                    break;
                case ConsoleKey.DownArrow:
                   
                    break;
                case ConsoleKey.:

                    break;
            }
        }
        public void Main()
        {

            ConsoleKey key;
            do
            {
                ConsoleKeyInfo info = Console.ReadKey();
                key = info.Key;
            } while (true);
        }
    }
}

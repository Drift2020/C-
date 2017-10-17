using System;
using System.Windows.Forms;
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

        void Menu(Keys key)
        {
            
            switch (key)
            {
                case Keys.Left:
                   
                    break;
                case Keys.Right:
                 
                    break;
                case Keys.Up:
                 
                    break;
                case Keys.Down:
                   
                    break;
                case Keys.RShiftKey:

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

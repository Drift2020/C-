using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoreNET
{
    class Start
    {
        public static void Main()
        {
            Control cont=new Control();
            int Number = 0;
            cont.Load();
            cont.PrintMenu();
            do
            {


                Number = Convert.ToInt32(Console.ReadLine());
                switch (Number)
                {
                    case 1://add

                        Console.Clear();
                        cont.add();
                        Console.Clear();
                        cont.PrintMenu();

                        break;
                    case 2://Dell

                        Console.Clear();

                        cont.Delite();
                        //Console.Clear();
                        //cont.Print_menu();

                        break;
                    case 3://print

                        Console.Clear();
                        cont.Print();

                        break;
                    case 4://Edit

                        //Console.Clear();
                        //cont.print_list();
                        //Console.WriteLine("What is the number to be changed to be changed ?:");
                        //Number = Convert.ToInt32(Console.ReadLine());
                        //cont.Edit(Number);

                        break;
                    case 5://Search
                        //Console.Clear();
                        //cont.Search();

                        break;
                    case 6:

                        cont.Save();
                        return;


                    case 7:
                        Console.Clear();
                        cont.PrintMenu();
                        break;
                }

            } while (true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_Group
{
    class MAIN_Class
    {
        public static void Print()
        {
            Console.WriteLine("1.Add new student");
            Console.WriteLine("2.Delete of student");
            Console.WriteLine("3.Edit of student");
            Console.WriteLine("4.Print of group");
            Console.WriteLine("5.Search to student");
            Console.WriteLine("6.Save to file");
            Console.WriteLine("7.Load to file");
            Console.Write("Please select options:");
           
        }
        public static void Main()
        {
            Academy_Group Grup=new Academy_Group();
            bool work = true;
            
        
            do
            {
                try { 
                Print();
                int number = Convert.ToInt32(Console.ReadLine());
                    switch(number)
                    {
                        case 1:
                            Console.Clear();
                            Grup.Add();
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            Grup.Print();
                            Grup.Remove();
                            Console.Clear();
                            Grup.Print();
                            
                            break;
                        case 3:
                            Console.Clear();
                            Grup.Print();
                            Grup.Edit();
                            Console.Clear();
                            Grup.Print();
                            break;
                        case 4:
                            Console.Clear();
                            Grup.Print();
                            break;
                        case 5:
                            Console.Clear();
                            Grup.Search();
                            break;
                        case 6:
                            Console.Clear();
                            Grup.Save();
                            break;
                        case 7:
                            Console.Clear();
                            Grup.Load();
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                }
                catch (Exception ex) { Console.Clear(); Console.WriteLine(ex); }
            } while (work);
        }
    }
}

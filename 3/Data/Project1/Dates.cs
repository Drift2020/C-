using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Dates
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public Dates()
        {
            Day = 25;
            Month = 9;
            Year = 1998;

        }
        public Dates(int d, int m, int y)
        {
            try
            {

                if (y > 0)
                {
                    if (m > 0 && m <= 12)
                    {
                        if (m == 4 || m == 6 || m == 9 || m == 11)
                        {
                            if (d > 0 && Day <= 30)
                            {
                                Year = y;
                                Month = m;
                                Day = d;
                            }
                            else
                            {
                                throw new Exception("Недопустимое значение дня: " + d);
                            }
                        }
                        else if (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12)
                        {
                            if (d > 0 && d <= 31)
                            {
                                Year = y;
                                Month = m;
                                Day = d;
                            }
                            else
                            {
                                throw new Exception("Недопустимое значение дня: " + d);
                            }
                        }
                        else if (y % 4 == 0 && y % 100 != 0 || y % 400 == 0)
                        {

                            if (d > 0 && d <= 29 && m == 2)
                            {
                                Year = y;
                                Month = m;
                                Day = d;
                            }
                        }
                        else if (d > 0 && d <= 28 && m == 2)
                        {
                            Year = y;
                            Month = m;
                            Day = d;
                        }
                        else
                        {
                            throw new Exception("Недопустимое значение дня: " + d);
                        }
                    }
                    else
                    {
                        throw new Exception("Недопустимое значение месяца: " + m);
                    }
                }
                else
                {
                    throw new Exception("Недопустимое значение года: " + y);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void Corect()
        {
            bool v = false;
            if (Year % 4 == 0 && Year % 100 != 0 || Year % 400 == 0)
                v = true;
            if (Month == 2 && Day > 28 && v == false)
            {
                Day = 1;
                Month++;
            }
            else if (Month == 2 && Day > 29 && v == true)
            {
                Day = 1;
                Month++;
            }
            if (Month > 12)
            {
                Day = 1;
                Month = 1;
                Year++;
            }
            if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
            {
                if (Day > 31)
                {
                    Day = 1;
                    Month++;
                }
                else if (Day < 1)
                {
                    if (Month == 4 || Month == 6 || Month == 9 || Month == 11)
                    {
                        Day = 30;
                        Month--;
                    }
                    else if (Month == 7)
                    {
                        Day = 31;
                        Month--;
                    }
                    else if (Month == 2 && v == false)
                    {
                        Day = 28;
                        Month--;
                    }
                    else if (Month == 2 && v == true)
                    {
                        Day = 29;
                        Month--;
                    }
                }
            }
            if (Month == 4 || Month == 6 || Month == 9 || Month == 11)
            {
                if (Day > 30)
                {
                    Day = 1;
                    Month++;
                }
                if (Day < 1)
                {
                    Day = 31;
                    Month--;
                }
            }
        }
        public static int operator -(Dates op1, Dates op2)
        {
            int result;
            result = ((op1.Year - 1) * 365 + op1.Year / 4) - ((op2.Year - 1) * 365 + op2.Year / 4);

            for (int i = 1; i < op1.Month; i++)
            {
                if (i == 4 || i == 6 || i == 9 || i == 11)
                    result += 30;
                else if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12)
                    result += 31;
                else if ((op1.Year % 4 == 0 && op1.Year % 100 != 0 || op1.Year % 400 == 0) && i == 2)
                {
                    result += 29;
                }
                else
                {
                    result += 28;
                }
            }
            for (int i = 1; i < op1.Month; i++)
            {
                if (i == 4 || i == 6 || i == 9 || i == 11)
                    result -= 30;
                else if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12)
                    result -= 31;
                else if ((op2.Year % 4 == 0 && op2.Year % 100 != 0 || op2.Year % 400 == 0) && i == 2)
                {
                    result -= 29;
                }
                else
                {
                    result -= 28;
                }
            }

            result += op1.Day - op2.Day;


            return result;
        }
        public static Dates operator +(Dates op1, int op2)
        {
            for (int i = 1; i <= op2; i++)
            {
                op1.Day++;
                op1.Corect();
            }
            return op1;
        }
        public static Dates operator ++(Dates op)
        {
            Dates result = new Dates();
            result.Day = op.Day + 1;
            result.Month = op.Month;
            result.Year = op.Year;
            result.Corect();
            return result;
        }
        public static Dates operator --(Dates op)
        {
            Dates result = new Dates();
            result.Day = op.Day - 1;
            result.Month = op.Month;
            result.Year = op.Year;
            result.Corect();
            return result;
        }
        public static bool operator <(Dates op1, Dates op2)
        {
           if(op1.Year<op2.Year)
           {
               return true;
           }              
           else  if(op1.Year==op2.Year)
           {
               if(op1.Month<op2.Month)
               {
                   return true;
               }
               else if(op1.Month==op2.Month)
               {
                   if(op1.Day<op2.Day)
                   {
                       return true;
                   }
                   else
                   {
                       return false;
                   }
               }
           }
           return false;

        }
        public static bool operator >(Dates op1, Dates op2)
        {
            if (op1.Year > op2.Year)
            {
                return true;
            }
            else if (op1.Year == op2.Year)
            {
                if (op1.Month > op2.Month)
                {
                    return true;
                }
                else if (op1.Month == op2.Month)
                {
                    if (op1.Day > op2.Day)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;

        }
        public static bool operator ==(Dates op1, Dates op2)
        {
            if ((op1.Day == op2.Day) && (op1.Month == op2.Month) &&
            (op1.Year == op2.Year))
                return true;
            else
                return false;
        }
        public static bool operator !=(Dates op1, Dates op2)
        {
            if ((op1.Day != op2.Day) || (op1.Month != op2.Month) ||
            (op1.Year != op2.Year))
                return true;
            else
                return false;
        }
        public void prints()
        {
            Console.Write("{0}.{1}.{2}", Day, Month, Year);
        }
    }
    class DatesDDemo
    {

        public static void Main()
        {
            Dates OneDate = new Dates();


            do
            {
                try
                {
                    int number = 0;
                    Console.WriteLine("Создание даты по умолчанию: 1");
                    Console.WriteLine("Создание даты : 2");
                    Console.WriteLine("Разница между двумя датами: 3");
                    Console.WriteLine("Изменение даты на заданное количество дней: 4");
                    Console.WriteLine("++: 5");
                    Console.WriteLine("--: 6");
                    Console.WriteLine(">: 7");
                    Console.WriteLine("<: 8");
                    Console.WriteLine("==: 9");
                    Console.WriteLine("!=: 10");
                    Console.WriteLine("Вывод даты: 11");
                    Console.WriteLine("Очистка консоли: 12");
                    number = Convert.ToInt32(Console.ReadLine());
                    switch (number)
                    {
                        case 1:
                            {
                                OneDate = new Dates();
                                Console.Clear();
                            }
                            break;
                        case 2:
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.Write("Введите день: ");
                                    int Day = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Введите месяц: ");
                                    int M = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Введите год: ");
                                    int Y = Convert.ToInt32(Console.ReadLine());

                                    OneDate = new Dates(Day, M, Y);
                                    Console.Clear();
                                }
                                catch (Exception ex)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ex);
                                }
                            }
                            break;
                        case 3:
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.Write("Введите день: ");
                                    int Day = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Введите месяц: ");
                                    int M = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Введите год: ");
                                    int Y = Convert.ToInt32(Console.ReadLine());

                                    Dates TDate = new Dates(Day, M, Y);


                                    Console.WriteLine(OneDate - TDate);
                                }
                                catch (Exception ex)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ex);
                                }
                            }
                            break;
                        case 4:
                            try
                            {
                                Console.Clear();
                                Console.Write("Введите количество дней: ");
                                int Day = Convert.ToInt32(Console.ReadLine());

                                OneDate = OneDate + Day;
                            }
                            catch (Exception ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex);
                            }
                            break;
                        case 5:
                            try
                            {
                                Console.Clear();
                                OneDate++;

                                OneDate.prints();
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                            catch (Exception ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex);
                            }
                            break;
                        case 6:
                            try
                            {
                                Console.Clear();
                                OneDate--;

                                OneDate.prints();
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                            catch (Exception ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex);
                            }
                            break;
                        case 7:
                            try
                            {
                                Console.Clear();
                                Console.Write("Введите день: ");
                                int Day = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Введите месяц: ");
                                int M = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Введите год: ");
                                int Y = Convert.ToInt32(Console.ReadLine());

                                Dates TDate = new Dates(Day, M, Y);
                                Console.Clear();

                                if (OneDate > TDate)
                                {
                                    Console.WriteLine("Первая дата больше:");
                                    OneDate.prints();
                                    Console.Write(">");
                                    TDate.prints();
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("Первая дата не больше:");

                                }
                            }
                            catch (Exception ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex);
                            }
                            break;
                        case 8:
                            try
                            {
                                Console.Clear();
                                Console.Write("Введите день: ");
                                int Day = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Введите месяц: ");
                                int M = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Введите год: ");
                                int Y = Convert.ToInt32(Console.ReadLine());

                                Dates TDate = new Dates(Day, M, Y);
                                Console.Clear();

                                if (OneDate < TDate)
                                {
                                    Console.WriteLine("Первая дата меньше:");
                                    OneDate.prints();
                                    Console.Write("<");
                                    TDate.prints();
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("Первая дата не меньше:");
                                   
                                }
                              
                            }
                            catch (Exception ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex);
                            }
                            break;
                        case 9:
                            try
                            {
                                Console.Clear();
                                Console.Write("Введите день: ");
                                int Day = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Введите месяц: ");
                                int M = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Введите год: ");
                                int Y = Convert.ToInt32(Console.ReadLine());

                                Dates TDate = new Dates(Day, M, Y);
                                Console.Clear();

                                if (OneDate == TDate)
                                {
                                    Console.WriteLine("Даты равны:");
                                    OneDate.prints();
                                    Console.Write("==");
                                    TDate.prints();
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("Даты неравны:");

                                }

                            }
                            catch (Exception ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex);
                            }
                            break;
                        case 10:
                            try
                            {
                                Console.Clear();
                                Console.Write("Введите день: ");
                                int Day = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Введите месяц: ");
                                int M = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Введите год: ");
                                int Y = Convert.ToInt32(Console.ReadLine());

                                Dates TDate = new Dates(Day, M, Y);
                                Console.Clear();

                                if (OneDate != TDate)
                                {
                                    Console.WriteLine("Даты неравны:");
                                    OneDate.prints();
                                    Console.Write("!=");
                                    TDate.prints();
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("Даты равны:");

                                }

                            }
                            catch (Exception ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex);
                            }
                            break;
                        case 11:
                            Console.Clear();
                            OneDate.prints();
                            Console.WriteLine();
                            Console.WriteLine();
                            break;
                        case 12:
                            Console.Clear();
                            break;
                        default:

                            break;
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            } while (true);


        }
    }
}

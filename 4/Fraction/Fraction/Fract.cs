using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    class Fract
    {
        public double A { get; set; }
        public double B { get; set; }
        public Fract()
        {
            A = 1;
            B = 10;
        }
        public Fract(double a,double b)
        {
            A = a;
            B = b;
        }
        public static Fract operator +(Fract f1, Fract f2)
        {
            Fract f3=new Fract();
            double Dividend_a = f1.A;
            double Dividend_a1 = f2.A;

            double divider_b = f1.B;
            double divider_b1 = f2.B;

            double divider_b_1 = divider_b;

            if (divider_b != divider_b1)
            {
                divider_b *= divider_b1;
                Dividend_a *= divider_b1;
                Dividend_a1 *= divider_b_1;
            }

            f3.A=(Dividend_a + Dividend_a1);
            f3.B=(divider_b);
            f3.nod();
            return f3;
        }
        public static Fract operator -(Fract f1, Fract f2)
        {
            Fract f3 = new Fract();
            double Dividend_a = f1.A;
            double divider_b = f1.B;

            double Dividend_a1 = f2.A;
            double divider_b1 = f2.B;

            double divider_b_1 = divider_b;

            Dividend_a *= divider_b1;
            divider_b *= divider_b1;

            Dividend_a1 *= divider_b_1;
            divider_b1 *= divider_b_1;


            f3.A = (Dividend_a - Dividend_a1);
            f3.B = (divider_b);
            f3.nod();
            return f3;
        }
        public static Fract operator /(Fract f1, Fract f2)
        {
            Fract f3=new Fract();
            double Dividend_a = f1.A;
            double divider_b = f1.B;
            double Dividend_a1 = f2.B;
            double divider_b1 = f2.A;

            divider_b *= divider_b1;
            Dividend_a *= Dividend_a1;


            f3.A=(Dividend_a);
            f3.B=(divider_b);
            f3.nod();
            return f3;
        }      
        public static Fract operator *(Fract f1, Fract f2)
        {
            Fract f3=new Fract();

            double Dividend_a = f1.A;
            double divider_b = f1.B;

            double Dividend_a1 = f2.A;
            double divider_b1 = f2.B;

            f3.A=(Dividend_a1 * Dividend_a);
            f3.B=(divider_b1 * divider_b);
            f3.nod();
            return f3;
        }
        public static bool operator ==(Fract f1, Fract f2)
        {
            if (f1.A * f2.B == f1.B * f2.A)
            {
                return true;
            }
            else
                return false;
        }
        public static bool operator !=(Fract f1, Fract f2)
        {
            if (f1.A * f2.B != f1.B * f2.A)
            {
                return true;
            }
            else
                return false;
        }
        public static bool operator <(Fract f1, Fract f2)
        {
            Fract f3 = f1 - f2;
            if (f3.A < 0)
                return true;
            else
                return false;
        }

        public static bool operator false(Fract f1)
        {
            if (f1.A>f1.B)
                return true;
            return false;
        }


        public static bool operator true(Fract f1)
        {
            if (f1.A < f1.B)
                return true;
            return false;
        }
      
        public static bool operator >(Fract f1, Fract f2)
        {
        Fract f3=f1-f2;
        if (f3.A > 0)
            return true;
        else
            return false;
        }
     public void nod()
    {
       
       
             double a = (A), b = (B), c = 0;
             while (b > 0)
             {
                 c = a % b;
                 a = b;
                 b = c;
             }
             A /= Math.Abs(a);
             B /= Math.Abs(a);
        
       
    }
        public void print()
        {
            if (B == 1)
            {
                Console.WriteLine(A);
            }
            else
            {


                Console.WriteLine(A);
                Console.WriteLine("--");
                Console.WriteLine(B);
            }
        }
    }
    class Test
    {
        public static void Print()
        {
            Console.WriteLine("Создание дроби по умолчанию (1/10): 1");
            Console.WriteLine("Создание дроби: 2");
            Console.WriteLine("+ : 3");
            Console.WriteLine("- : 4");
            Console.WriteLine("* : 5");
            Console.WriteLine("/ : 6");
            Console.WriteLine("== : 7");
            Console.WriteLine("!= : 8");
            Console.WriteLine("< : 9");
            Console.WriteLine("> : 10");
            Console.WriteLine("true : 11");
            Console.WriteLine("false : 12");
            Console.WriteLine("Фрагмент кода который в PDF : 13");
            Console.Write("Выбор: ");
        }
        public static void Main()
        {
            try {
                Fract OneF = new Fract();
                bool work = true;
                do
                {
                    try {
                        Print();
                        int numder = 0;
                        numder = Convert.ToInt32(Console.ReadLine());
                        switch (numder)
                        {
                            case 1:
                                Console.Clear();
                                OneF = new Fract();
                                break;
                            case 2:
                                try
                                {
                                    Console.Clear();
                                    Console.Write("Введите числитель: ");
                                    double A = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Введите знаменатель: ");
                                    double B = Convert.ToInt32(Console.ReadLine());


                                    OneF = new Fract(A, B);
                                    Console.Clear();
                                }
                                catch (Exception ex)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ex);
                                }
                                break;
                            case 3:
                                try
                                {
                                    Console.Clear();
                                    Console.Write("Введите числитель: ");
                                    double A = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Введите знаменатель: ");
                                    double B = Convert.ToInt32(Console.ReadLine());

                                  

                                    Fract TFract = new Fract(A,B);

                                    (OneF + TFract).print();                                
                                    Console.WriteLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ex);
                                }
                                break;
                            case 4:
                                try
                                {
                                    Console.Clear();
                                    Console.Write("Введите числитель: ");
                                    double A = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Введите знаменатель: ");
                                    double B = Convert.ToInt32(Console.ReadLine());



                                    Fract TFract = new Fract(A, B);

                                    (OneF - TFract).print();
                                    Console.WriteLine();
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
                                    Console.Write("Введите числитель: ");
                                    double A = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Введите знаменатель: ");
                                    double B = Convert.ToInt32(Console.ReadLine());



                                    Fract TFract = new Fract(A, B);

                                    (OneF * TFract).print();
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
                                    Console.Write("Введите числитель: ");
                                    double A = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Введите знаменатель: ");
                                    double B = Convert.ToInt32(Console.ReadLine());



                                    Fract TFract = new Fract(A, B);

                                    (OneF / TFract).print();
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
                                    Console.Write("Введите числитель: ");
                                    double A = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Введите знаменатель: ");
                                    double B = Convert.ToInt32(Console.ReadLine());



                                    Fract TFract = new Fract(A, B);

                                    if (OneF == TFract)
                                    {
                                        Console.Clear();
                                        OneF.print();
                                        Console.Write(" равен ");
                                        TFract.print();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        OneF.print();
                                        Console.Write(" не равен ");
                                        TFract.print();
                                    }
                                    Console.WriteLine();
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
                                    Console.Write("Введите числитель: ");
                                    double A = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Введите знаменатель: ");
                                    double B = Convert.ToInt32(Console.ReadLine());



                                    Fract TFract = new Fract(A, B);

                                    if (OneF != TFract)
                                    {
                                        Console.Clear();
                                        OneF.print();
                                        Console.Write(" не равен ");
                                        TFract.print();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        OneF.print();
                                        Console.Write("  равен ");
                                        TFract.print();
                                    }
                                    Console.WriteLine();
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
                                    Console.Write("Введите числитель: ");
                                    double A = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Введите знаменатель: ");
                                    double B = Convert.ToInt32(Console.ReadLine());



                                    Fract TFract = new Fract(A, B);

                                    if (OneF < TFract)
                                    {
                                        Console.Clear();
                                        OneF.print();
                                        Console.Write(" меньше чем ");
                                        TFract.print();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        OneF.print();
                                        Console.Write(" не меньше чем ");
                                        TFract.print();
                                    }
                                    Console.WriteLine();
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
                                    Console.Write("Введите числитель: ");
                                    double A = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Введите знаменатель: ");
                                    double B = Convert.ToInt32(Console.ReadLine());



                                    Fract TFract = new Fract(A, B);

                                    if (OneF > TFract)
                                    {
                                        Console.Clear();
                                        OneF.print();
                                        Console.Write(" больше чем ");
                                        TFract.print();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        OneF.print();
                                        Console.Write(" не больше чем ");
                                        TFract.print();
                                    }
                                    Console.WriteLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ex);
                                }
                                break;
                            case 11:
                                try
                                {
                                    if (OneF)
                                    {
                                        Console.Clear();
                                       
                                        Console.WriteLine("Дробь правельная ");
                                        OneF.print();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Дробь неправельная ");
                                        OneF.print();
                                    }
                                    Console.WriteLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ex);
                                }
                                break;
                            case 12:
                                try
                                {
                                    if (OneF)
                                    {
                                        Console.Clear();

                                        Console.WriteLine("Дробь правельная ");
                                        OneF.print();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Дробь неправельная ");
                                        OneF.print();
                                    }
                                    Console.WriteLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ex);
                                }
                                break;
                            case 13:
                                break;
                            default:
                                Console.Clear();
                                break;
                        }
                    } catch (Exception ex) { Console.Clear(); Console.WriteLine(ex);}
                } while (work);
            } catch(Exception ex) { Console.Clear(); Console.WriteLine(ex); }
        }

    }
}

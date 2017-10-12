using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Pyton
{
    delegate void MyDelegate();
    class ConsoleWrite
    {
        enum Direction { UP, RIGHT, DOWN, LEFT };
        static Direction d = Direction.RIGHT;
        static Snake Pl = new Snake();
        static Map ObjMap = new Map();
        static Obj Ap = new Obj();
        ConsoleWrite()
        {

        }


        static void Main(string[] args)
        {

            Ap.RegisterHandler(new Obj.ConsolDelegate(PrintAp));
            Ap.RegisterHandler2(new Obj.ConsolDelegate2(CordProvAp));
            Ap.RegisterHandler3(new Obj.ConsolDelegate3(Updete));

            ObjMap.RegisterHandler(new Map.ConsolDelegate(PrintMap));
            ObjMap.RegisterHandler(new Map.ConsolDelegate(PrintMap));
            ObjMap.print();

            Pl.RegisterHandler(new Snake.ConsolDelegate(PrintSnake));
            Pl.RegisterHandler2(new Snake.ConsolDelegate2(PrintSnakeEnd));
            Pl.RegisterHandler2(new Snake.ConsolDelegate2(CordProvSnake));
            Console.CursorVisible = false;
            Timer t = new Timer();
            t.Interval = 100;
            // public event ElapsedEventHandler Elapsed - это событие происходит по истечении интервала времени
            t.Elapsed += new ElapsedEventHandler(OnTimer);

            t.Start(); // Начинает вызывать событие Elapsed
            ConsoleKey key;

            do
            {
                ConsoleKeyInfo info = Console.ReadKey();
                key = info.Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if (Pl.listSize.Count == 1)
                            d = Direction.LEFT;
                        else if (d != Direction.RIGHT)
                            d = Direction.LEFT;
                        break;
                    case ConsoleKey.RightArrow:
                        if (Pl.listSize.Count == 1)
                            d = Direction.RIGHT;
                        else if (d != Direction.LEFT)
                            d = Direction.RIGHT;
                        break;
                    case ConsoleKey.UpArrow:
                        if (Pl.listSize.Count == 1)
                            d = Direction.UP;
                        else if (d != Direction.DOWN)
                            d = Direction.UP;
                        break;
                    case ConsoleKey.DownArrow:
                        if (Pl.listSize.Count == 1)
                            d = Direction.DOWN;
                        else if (d != Direction.UP)
                            d = Direction.DOWN;
                        break;
                }
            } while (key != ConsoleKey.Escape && Pl.HP == true);
        }

        private static void OnTimer(object sender, ElapsedEventArgs arg /* Предоставляет данные для события Elapsed */)
        {

            Pl.PrintSnakeEnd(ObjMap);
            Ap.Print();
            Ap.Updete(ObjMap);

            Pl.TempY = Pl.listSize[0].Y;
            Pl.TempX = Pl.listSize[0].X;
            Pl.Tempdirect = Pl.listSize[0].direct;

            switch (d)
            {
                case Direction.UP:
                    if (Pl.listSize[0].Y > 0)
                    {
                        --Pl.listSize[0].Y;
                        Pl.listSize[0].direct = 0;
                    }
                    break;
                case Direction.RIGHT:
                    if (Pl.listSize[0].X < ObjMap.Width - 1)
                    {
                        ++Pl.listSize[0].X;
                        Pl.listSize[0].direct = 2;
                    }
                    break;
                case Direction.DOWN:
                    if (Pl.listSize[0].Y < ObjMap.Height - 1)
                    {
                        ++Pl.listSize[0].Y;
                        Pl.listSize[0].direct = 1;
                    }
                    break;
                case Direction.LEFT:
                    if (Pl.listSize[0].X > 0)
                    {
                        --Pl.listSize[0].X;
                        Pl.listSize[0].direct = 3;
                    }
                    break;
            }
            Pl.CordsSnake();
            Pl.PrintSnake();
            Ap.CordProv(Pl);
        }
        private static void PrintMap(object obj)
        {
            Console.Clear();
            for (int y = 0; y < ((Map)obj).Height; y++)
            {
                for (int x = 0; x < ((Map)obj).Width; x++)
                {
                    Console.Write(((Map)obj).onPsevdoPrint(x, y));
                }
                Console.WriteLine();
            }
        }
        private static void PrintSnake(object obj)
        {


            Console.SetCursorPosition(((Snake)obj).listSize[0].X, ((Snake)obj).listSize[0].Y);
            Console.Write((char)2);
            for (int i = 1; i < ((Snake)obj).listSize.Count; i++)
            {
                Console.SetCursorPosition(((Snake)obj).listSize[i].X, ((Snake)obj).listSize[i].Y);
                Console.Write((char)3);
            }

        }
        private static void PrintSnakeEnd(object obj, object obj2)
        {
            Console.SetCursorPosition(((Snake)obj).listSize[0].X, ((Snake)obj).listSize[0].Y);
            Console.Write(((Map)obj2).onPsevdoPrint(((Snake)obj).listSize[0].X, ((Snake)obj).listSize[0].Y));

            for (int i = 1; i < ((Snake)obj).listSize.Count; i++)
            {
                Console.SetCursorPosition(((Snake)obj).listSize[i].X, ((Snake)obj).listSize[i].Y);
                Console.Write(((Map)obj2).onPsevdoPrint(((Snake)obj).listSize[0].X, ((Snake)obj).listSize[0].Y));
            }
        }
        private static void PrintAp(object obj)
        {
            if (((Obj)obj).Enable == true)
            {
                Console.SetCursorPosition(((Obj)obj).X, ((Obj)obj).Y);
                Console.Write((char)4);
            }
        }
        private static void CordProvAp(object obj, object obj2)
        {
            if (((Obj)obj).X == ((Snake)obj2).listSize[0].X &&
               ((Obj)obj).Y == ((Snake)obj2).listSize[0].Y &&
                ((Obj)obj).Enable == true)
            {
                ((Snake)obj2).Add();
                ((Snake)obj2).Score++;
                ((Obj)obj).Enable = false;
            }
        }
        private static void Updete(object obj, object obj2)
        {
            if (((Obj)obj).Enable == false)
            {
                Random t = new Random();
                ((Obj)obj).X = 1 + t.Next(((Map)obj2).Width - 2);
                ((Obj)obj).Y = 1 + t.Next(((Map)obj2).Height - 2);
                ((Obj)obj).Enable = true;
            }
        }
        private static void CordProvSnake(object obj, object obj2)
        {
            if (((Snake)obj).listSize[0].X == ((Map)obj2).Width - 1 ||
               ((Snake)obj).listSize[0].X == 0 ||
               ((Snake)obj).listSize[0].Y == ((Map)obj2).Height - 1 ||
               ((Snake)obj).listSize[0].Y == 0)
            {
                ((Snake)obj).HP = false;
            }
            for (int i = 1; i < ((Snake)obj).listSize.Count; i++)
            {
                if (((Snake)obj).listSize[i].X == ((Snake)obj).listSize[0].X &&
                    ((Snake)obj).listSize[i].Y == ((Snake)obj).listSize[0].Y)
                {

                    ((Snake)obj).HP = false;
                    break;
                }


            }


        }
    }
}

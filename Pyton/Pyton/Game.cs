//using System;
//using System.Timers;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Pyton
//{
//    class Game
//    {
//        enum Direction { UP, RIGHT, DOWN, LEFT };
//        static Direction d = Direction.RIGHT;

//       static Map Maps;
//       static Snake Pl;
//        Game()
//        {
//             Pl = new Snake();
//             Maps = new Map();
//            // DelegatePrint Print = new DelegatePrint();
//        }
//        public void Starts()
//        {

//            Timer t = new Timer();
//            t.Interval = 100;
//            // public event ElapsedEventHandler Elapsed - это событие происходит по истечении интервала времени
//            t.Elapsed += new ElapsedEventHandler(OnTimer);
//            t.Start(); // Начинает вызывать событие Elapsed
//            ConsoleKey key;
//            Console.CursorVisible = false;
//            do
//            {
//                ConsoleKeyInfo info = Console.ReadKey();
//                key = info.Key;
//                switch (key)
//                {
//                    case ConsoleKey.LeftArrow:
//                        d = Direction.LEFT;
//                        break;
//                    case ConsoleKey.RightArrow:
//                        d = Direction.RIGHT;
//                        break;
//                    case ConsoleKey.UpArrow:
//                        d = Direction.UP;
//                        break;
//                    case ConsoleKey.DownArrow:
//                        d = Direction.DOWN;
//                        break;
//                }
//            } while (key != ConsoleKey.Escape);
//        }
//        private static void OnTimer(object sender, ElapsedEventArgs arg /* Предоставляет данные для события Elapsed */)
//        {
//            switch (d)
//            {
//                case Direction.UP:
//                    if (((Sizes)Pl.listSize[0]).Y > 0)
//                        ((Sizes)Pl.listSize[0]).Y--;
//                    break;
//                case Direction.RIGHT:
//                    if (((Sizes)Pl.listSize[0]).X < Maps.Width - 1)
//                        ((Sizes)Pl.listSize[0]).X++; 
//                    break;
//                case Direction.DOWN:
//                    if (((Sizes)Pl.listSize[0]).Y < Maps.Height - 1)
//                        ((Sizes)Pl.listSize[0]).Y++;
//                    break;
//                case Direction.LEFT:
//                    if (((Sizes)Pl.listSize[0]).X > 0)
//                        ((Sizes)Pl.listSize[0]).X--;
//                    break;
//            }

//            Console.Clear();
//            Console.SetCursorPosition(((Sizes)Pl.listSize[0]).X, ((Sizes)Pl.listSize[0]).Y);
//            Console.Write((char)2);
//        }
//    }
//}

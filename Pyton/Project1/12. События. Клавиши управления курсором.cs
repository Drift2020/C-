using System;
using System.Timers;

namespace ReadKey
{
    class Program
    {
        enum Direction { UP, RIGHT, DOWN, LEFT };
        static Direction d = Direction.RIGHT;
        static int x = 0, y = 0;
        static void Main(string[] args)
        {
            Timer t = new Timer();
            t.Interval = 100;
            // public event ElapsedEventHandler Elapsed - ��� ������� ���������� �� ��������� ��������� �������
            t.Elapsed += new ElapsedEventHandler(OnTimer);
            t.Start(); // �������� �������� ������� Elapsed
            ConsoleKey key;
            Console.CursorVisible = false;
            do
            {
                ConsoleKeyInfo info = Console.ReadKey();
                key = info.Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        d = Direction.LEFT;
                        break;
                    case ConsoleKey.RightArrow:
                        d = Direction.RIGHT;
                        break;
                    case ConsoleKey.UpArrow:
                        d = Direction.UP;
                        break;
                    case ConsoleKey.DownArrow:
                        d = Direction.DOWN;
                        break;
                }
            } while (key != ConsoleKey.Escape);
        }

        private static void OnTimer(object sender, ElapsedEventArgs arg /* ������������� ������ ��� ������� Elapsed */)
        {
            switch (d)
            {
                case Direction.UP:
                    if (y > 0)
                        --y;
                    break;
                case Direction.RIGHT:
                    if (x < Console.WindowWidth - 1)
                        ++x;
                    break;
                case Direction.DOWN:
                    if (y < Console.WindowHeight - 1)
                        ++y;
                    break;
                case Direction.LEFT:
                    if (x > 0)
                        --x;
                    break;
            }
            Console.SetCursorPosition(x, y);
            Console.Write((char)2);
            Console.Clear();


        }
    }
}

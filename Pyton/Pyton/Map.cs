using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyton
{
 
    class Map
    {
    
        enum Direction { Wall_Straight_Left_And_Rigth=9472,
            Wall_Straight_UP =166,
            Wall_Angle_Right_Up =9484,
            Wall_Angle_Left_Up =172,
            Wall_Angle_Right_Down=9496,
            Wall_Angle_Left_Down=28,
            Null =0 };
        private List<char>[] map;
        public int Width { get; set; }
        public int Height { get; set; }

        public Map():this(20,20)
        {

        }
        public Map(int TempWidth, int TempHeight)
        {
            Width = TempWidth;
            Height = TempHeight;
            map = new List<char>[Height];

            for (int y = 0; y < Width; y++)
            {
                map[y] = new List<char>();
                for (int x = 0; x < Height; x++)
                {
                    if (x == 0 && y != 0 && y != Width-1 || x == Height-1 && y != 0 && y != Width-1)
                        map[y].Add((char)Direction.Wall_Straight_UP);
                    if (y == Width-1 && x != 0 && x != Height-1 || y == 0 && x != 0 && x != Height-1)
                        map[y].Add((char)Direction.Wall_Straight_Left_And_Rigth);

                    if (x == 0 && y == 0)
                        map[y].Add((char)Direction.Wall_Angle_Right_Up);
                    else if (x == Height-1 && y == Width-1)
                        map[y].Add((char)Direction.Wall_Angle_Right_Down);
                    else if (x == Height-1 && y == 0)
                        map[y].Add((char)Direction.Wall_Angle_Left_Up);
                    else if (x == 0 && y == Width-1)
                        map[y].Add((char)Direction.Wall_Angle_Left_Down);
                    else if (y != 0 && y != Width -1&& x!=0&&x!= Height-1)
                        map[y].Add((char)Direction.Null);

                    
                   
                }
            }
        }
        public char onPsevdoPrint(int x, int y)
        {
            try
            {
                return map[y][x];
            }
            catch
            {
                Console.WriteLine("Position not variatn");
                return '0';
            }

        }

        public void print()
        {
            if (list.Count != 0)
                foreach (ConsolDelegate i in list)
                {
                    i(this);
                }
        }

        public delegate void ConsolDelegate(object obj_map);
        List<ConsolDelegate> list = new List<ConsolDelegate>();
        public event ConsolDelegate Print
        {
            // Используем аксессоры событий
            add
            {
                list.Add(value);
            }

            remove
            {
                list.Remove(value);
            }
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyton
{
    class Map
    {
        private List<char>[] map;
        public int Width { get; set; }
        public int Height { get; set; }
        public Map()
        {
            Width = 20;
            Height = 20;
            map = new List<char>[Height];

            for (int y = 0; y < Width; y++)
            {
                map[y] = new List<char>();
                for (int x = 0; x < Height; x++)
                {
                    if (x == 0 && y != 0 && y != 19 || x == 19 && y != 0 && y != 19)
                        map[y].Add((char)166);
                    if (y == 19 && x != 0 && x != 19 || y == 0 && x != 0 && x != 19)
                        map[y].Add((char)9472);

                    if (x == 0 && y == 0)
                        map[y].Add((char)9484);
                    else if (x == 19 && y == 19)
                        map[y].Add((char)9496);
                    else if (x == 19 && y == 0)
                        map[y].Add((char)172);
                    else if (x == 0 && y == 19)
                        map[y].Add((char)28);
                    else if (y != 0 && y != 19&&x!=0&&x!=19)
                        map[y].Add((char)0);

                    
                   
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
            if (del != null)
                del(this);
        }

        public delegate void ConsolDelegate(object obj);
        // Создаем переменную делегата
        internal ConsolDelegate del;

        public void RegisterHandler(ConsolDelegate _del)
        {
            // метод Combine объединяет делегаты _del и del в один, 
            // который потом присваивается переменной del
            System.Delegate mainDel = System.Delegate.Combine(del, _del);
            del = mainDel as ConsolDelegate;

            // сокращенная форма добавления 
            // del += _del; // добавляем делегат
        }

        // Отмена регистрации делегата
        public void UnregisterHandler(ConsolDelegate _del)
        {
            // метод Remove возвращает делегат, из списка вызовов которого удален делегат _del
            System.Delegate mainDel = System.Delegate.Remove(del, _del);
            del = mainDel as ConsolDelegate;

            // сокращенная форма удаления 
            // del -= _del; // добавляем делегат
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyton
{
   public class Sizes
    {     
        public int X { get; set; }
        public int Y { get; set; }
        public int direct { get; set; }
    }

    
    class Snake
    {
        public int Score { get; set; }
        public int TempX { get; set; }
        public int TempY { get; set; }
        public int Tempdirect { get; set; }
        public bool HP { get; set; }
        public char head = (char)2;
        public List<Sizes> listSize;
        
        public Snake()
        {
            listSize = new List<Sizes>();
            Sizes temp=new Sizes();
            temp.X = 5;
            temp.Y = 1;
            temp.direct = 2;
            listSize.Add(temp);
            HP = true;
            TempX = temp.X;
            TempY = temp.Y;
            Tempdirect = temp.direct;            
        }

        public void Add(){
            Sizes temp = new Sizes();
            if(listSize[listSize.Count-1].direct==0)
            {

                temp.X = listSize[listSize.Count - 1].X;
                temp.Y =  listSize[listSize.Count - 1].Y+1;
                temp.direct = 0;
                listSize.Add(temp);

            }
            else if (listSize[listSize.Count - 1].direct == 1)
            {
                temp.X = listSize[listSize.Count - 1].X;
                temp.Y = listSize[listSize.Count - 1].Y - 1;
                temp.direct = 1;
                listSize.Add(temp);
            }
            else if (listSize[listSize.Count - 1].direct == 2)
            {
                temp.X = listSize[listSize.Count - 1].X-1;
                temp.Y = listSize[listSize.Count - 1].Y;
                temp.direct = 2;
                listSize.Add(temp);
            }
            else if (listSize[listSize.Count - 1].direct == 3)
            {
                temp.X = listSize[listSize.Count - 1].X+3;
                temp.Y = listSize[listSize.Count - 1].Y;
                temp.direct = 3;
                listSize.Add(temp);
            }
        }
        public void CordsSnake()
        {
            int TempX1 = TempX;
            int TempY1 = TempY;
            int Tempdirect1 = Tempdirect;

            int TempX2 = 0;
            int TempY2 = 0;
            int Tempdirect2 = 0;
            
            for (int i = 1; i < listSize.Count ; i++)
            {
                TempY2 = listSize[i].Y;
                TempX2 = listSize[i].X;
                Tempdirect2 = listSize[i].direct;

                listSize[i].X = TempX1;
                listSize[i].Y = TempY1;
                listSize[i].direct = Tempdirect1;

                TempX1 = TempX2;
                TempY1 = TempY2;
                Tempdirect1 = Tempdirect2;

            }          
        }

        public void PrintSnake()
        {
            if (del != null)
                del(this);
        }

        public void PrintSnakeEnd(object obj)
        {
            if (del2 != null)
                del2(this, obj);
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



        public delegate void ConsolDelegate2(object obj1, object obj2);
        // Создаем переменную делегата
        internal ConsolDelegate2 del2;
        public void RegisterHandler2(ConsolDelegate2 _del)
        {
            // метод Combine объединяет делегаты _del и del в один, 
            // который потом присваивается переменной del
            System.Delegate mainDel = System.Delegate.Combine(del2, _del);
            del2 = mainDel as ConsolDelegate2;

            // сокращенная форма добавления 
            // del += _del; // добавляем делегат
        }
        // Отмена регистрации делегата
        public void UnregisterHandler2(ConsolDelegate2 _del)
        {
            // метод Remove возвращает делегат, из списка вызовов которого удален делегат _del
            System.Delegate mainDel = System.Delegate.Remove(del2, _del);
            del2 = mainDel as ConsolDelegate2;

            // сокращенная форма удаления 
            // del -= _del; // добавляем делегат
        }
    }
}

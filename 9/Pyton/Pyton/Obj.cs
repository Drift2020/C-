using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyton
{
    class Obj
    {
        public int X{get;set;}
        public int Y{get;set;}
        public bool Enable { get; set; }
        public Obj(int x, int y)
        {
            X = x;
            Y = y;
            Enable = true;
        }
        public Obj(): this(5, 5)
        {
           
        }

        public void Print()
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

    


        public void CordProv(object obj)
        {
            if (del2 != null)
                del2(this, obj);
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



        public void Updete(object obj)
        {
            if (del3 != null)
                del3(this, obj);
        }
        public delegate void ConsolDelegate3(object obj1, object obj2);
        // Создаем переменную делегата
        internal ConsolDelegate3 del3;
        public void RegisterHandler3(ConsolDelegate3 _del)
        {
            // метод Combine объединяет делегаты _del и del в один, 
            // который потом присваивается переменной del
            System.Delegate mainDel = System.Delegate.Combine(del3, _del);
            del3 = mainDel as ConsolDelegate3;

            // сокращенная форма добавления 
            // del += _del; // добавляем делегат
        }
        // Отмена регистрации делегата
        public void UnregisterHandler3(ConsolDelegate3 _del)
        {
            // метод Remove возвращает делегат, из списка вызовов которого удален делегат _del
            System.Delegate mainDel = System.Delegate.Remove(del3, _del);
            del3 = mainDel as ConsolDelegate3;

            // сокращенная форма удаления 
            // del -= _del; // добавляем делегат
        }
    }
}

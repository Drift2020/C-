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

            if (list.Count != 0)
                foreach (ConsolDelegate i in list)
                {
                    i(this);
                }
        }
        public delegate void ConsolDelegate(object obj_snake);
        List<ConsolDelegate> list = new List<ConsolDelegate>();
        public event ConsolDelegate PrintEv
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
      
        public void CordProv(object obj)
        {
            if (list2.Count != 0)
                foreach (ConsolDelegate2 i in list2)
                {
                    i(this, obj);
                }
        }
        public delegate void ConsolDelegate2(object obj_ap, object obj2);
        List<ConsolDelegate2> list2 = new List<ConsolDelegate2>();
        public event ConsolDelegate2 CordProv2
        {
            // Используем аксессоры событий
            add
            {
                list2.Add(value);
            }

            remove
            {
                list2.Remove(value);
            }
        }





        public void Updete(object obj)
        {
            if (list2.Count != 0)
                foreach (ConsolDelegate3 i in list3)
                {
                    i(this, obj);
                }
        }
        public delegate void ConsolDelegate3(object obj_ap, object obj2);
        List<ConsolDelegate3> list3 = new List<ConsolDelegate3>();
        public event ConsolDelegate3 Updete1
        {
            // Используем аксессоры событий
            add
            {
                list3.Add(value);
            }

            remove
            {
                list3.Remove(value);
            }
        }

    }
}

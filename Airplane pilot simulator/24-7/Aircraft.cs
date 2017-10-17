using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_7
{
    delegate void Dis(object Aircraft);
    class Aircraft
    {
        int Height { get; set; }
        int Speed { get; set; }
        List<Dis> list = new List<Dis>();
        

        public event Dis observation
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
        public void Generator_Event_Observation()
        {
            Console.WriteLine("Произошло событие!!!");
            if (list.Count != 0)
                foreach (Dis i in list)
                {
                    i(this);
                }
        }
    }
}

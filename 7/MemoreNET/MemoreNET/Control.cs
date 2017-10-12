using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MemoreNET
{
    class Control
    {
        public List<Memore> OBJ;
        public Control()
        {

            OBJ = new List<Memore>();
        }

        public void selection()
        {
            Console.Clear();
            Console.WriteLine("1.USB\n2.HDD\n3.DVD\n");
        }

        void add_usb()
        {

            Console.Write("Enter Name producer: ");
            string ManufacturerName = Console.ReadLine();
            Console.Write("Enter Model: ");
            string Model = Console.ReadLine();
            Console.Write("Enter quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Price");
            int Price = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Size USB: ");
            int SizeUSB = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter speed USB: ");
            int SpeedUSB = Convert.ToInt32(Console.ReadLine());
            Memore p = new USB("USB", ManufacturerName, Model, quantity, Price, SizeUSB, SpeedUSB);

            OBJ.Add(p);
        }
        void add_dvd()
        {
            Console.Write("Enter Name producer: ");
            string ManufacturerName = Console.ReadLine();
            Console.Write("Enter Model: ");
            string Model = Console.ReadLine();
            Console.Write("Enter quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Price: ");
            int Price = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter spead load: ");
            int Speadload = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter spead save: ");
            int SpeadSave = Convert.ToInt32(Console.ReadLine());

            Memore p = new DVD("DVD", ManufacturerName, Model, quantity, Price, Speadload, SpeadSave);
            OBJ.Add(p);
        }
        void add_hdd()
        {
            Console.Write("Enter Name producer: ");
            string ManufacturerName = Console.ReadLine();
            Console.Write("Enter Model: ");
            string Model = Console.ReadLine();
            Console.Write("Enter quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Price: ");
            int Price = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter size load: ");
            int SizeP = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter spead save: ");
            int SpeedHDD = Convert.ToInt32(Console.ReadLine());

            Memore p = new HDD("HDD", ManufacturerName, Model, quantity, Price, SizeP, SpeedHDD);
            OBJ.Add(p);
        }
        public void add()
        {
            int number = 0;
            selection();
            number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1://USB

                    Console.Clear();
                    add_usb();

                    break;
                case 2://HDD

                    Console.Clear();
                    add_hdd();

                    break;
                case 3://DVD

                    Console.Clear();
                    add_dvd();

                    break;
            }
        }

        public void PrintMenu()
        {
            Console.WriteLine("1.Add object.");
            Console.WriteLine("2.Delete object.");
            Console.WriteLine("3.Print object.");
            Console.WriteLine("4.Change object.");
            Console.WriteLine("5.Search criteria.");
            Console.WriteLine("6.Exit.");
        }
        public void Print()
        {
            foreach (Memore P in OBJ)
            {
                P.Print();
                Console.WriteLine();
            }
            Console.WriteLine("7.Menu");
        }

        public void Edit()
        {

        }
        void SelectCriterDelite()
        {
            Console.WriteLine("1.Type");
            Console.WriteLine("2.Manufacturer name");
            Console.WriteLine("3.Model");
            Console.WriteLine("4.Quantity");
            Console.WriteLine("5.Price");

            Console.WriteLine("6.Spead load");
            Console.WriteLine("7.Spead save");

            Console.WriteLine("8.Size USB");
            Console.WriteLine("9.Speed USB");

            Console.WriteLine("10.Size");
            Console.WriteLine("11.Speed HDD");

            Console.WriteLine("12.Exit");
        }
        void DeliteManufacturerName()
        {
            Console.Clear();
            Console.Write("Please, enter manufacturer name to delite: ");
            string Temp = Console.ReadLine();
            for (int i = 0; i < OBJ.Count; i++)
            {
                if (String.Compare(OBJ[i].ManufacturerName, Temp) == 0)
                {
                    OBJ.Remove(OBJ[i]);
                    i = 0;
                }
            }
        }
        void DeliteUSB()
        {

            for (int i = 0; i < OBJ.Count; i++)
            {
                if (OBJ[i] is USB)
                {
                    OBJ.Remove(OBJ[i]);
                    i = 0;
                }
            }
        }
        void DeliteHDD()
        {

            for (int i = 0; i < OBJ.Count; i++)
            {
                if (OBJ[i] is HDD)
                {
                    OBJ.Remove(OBJ[i]);
                    i = 0;
                }
            }
        }
        void DeliteDVD()
        {
            for (int i = 0; i < OBJ.Count; i++)
            {
                if (OBJ[i] is DVD)
                {
                    OBJ.Remove(OBJ[i]);
                    i = 0;
                }
            }
        }
        void DeliteType()
        {
            selection();
            int number = 0;
            SelectCriterDelite();
            number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    DeliteUSB();
                    break;
                case 2:
                    DeliteHDD();
                    break;
                case 3:
                    DeliteDVD();
                    break;
            }

        }
        public void Delite()
        {
            int number = 0;
            SelectCriterDelite();
            number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    Console.Clear();
                    DeliteType();
                    Console.Clear();
                    PrintMenu();
                    break;
                case 2:
                    Console.Clear();
                    DeliteManufacturerName();
                    Console.Clear();
                    PrintMenu();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:

                    return;
            }
        }

        public void Serch()
        {

        }

        public void Save()
        {
            FileStream file = new FileStream("1.txt", FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);
            writer.Write(OBJ.Count);
            foreach (Memore P in OBJ)
            {
                P.Save(writer);
            }
            writer.Close();
            file.Close();
        }
        public void Load()
        {
            FileStream file = new FileStream("1.txt", FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(file);
            try
            {

                int size = reader.ReadInt32();
                Memore p;
                for (int i = 0; i < size - 1 && size > 0; i++)
                {
                    string LOAD = reader.ReadString();
                    if (String.Compare(LOAD, "USB") == 0)
                    {
                        p = new USB();
                        p.Load(reader, LOAD);
                        OBJ.Add(p);
                    }
                    else if (String.Compare(LOAD, "DVD") == 0)
                    {
                        p = new DVD();
                        p.Load(reader, LOAD);
                        OBJ.Add(p);
                    }
                    else if (String.Compare(LOAD, "HDD") == 0)
                    {
                        p = new HDD();
                        p.Load(reader, LOAD);
                        OBJ.Add(p);
                    }
                }
            }
            catch
            {

            };


            reader.Close();
            file.Close();
        }
    }
}

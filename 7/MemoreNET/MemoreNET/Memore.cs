using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MemoreNET
{
    abstract public class Memore
    {
        public Memore()
        {
            Name = null;
            ManufacturerName = null;
            Model = null;
            Size = 0;
            Price = 0;
        }
        public Memore(string Name, string ManufacturerName, string Model, int Size, int Price)
        {
            this.Name = Name;
            this.ManufacturerName = ManufacturerName;
            this.Model = Model;
            this.Size = Size;
            this.Price = Price;
        }
        public string Name
        {
            set;
            get;
        }
        public string ManufacturerName
        {
            set;
            get;
        }
        public string Model
        {
            set;
            get;
        }
        public int Size
        {
            set;
            get;
        }
        public int Price
        {
            set;
            get;
        }

        public virtual void Print()
        {
            Console.WriteLine("1.Name: {0}", Name);
            Console.WriteLine("2.Manufacturer name: {0}", ManufacturerName);
            Console.WriteLine("3.Model: {0}", Model);
            Console.WriteLine("4.Quantity: {0}", Size);
            Console.WriteLine("5.Price: {0}", Price);
           
        }
        public virtual void Load(BinaryReader reader, string Name)
        {
            this.Name = Name;
            ManufacturerName = reader.ReadString();
            Model = reader.ReadString();
            Size = reader.ReadInt32();
            Price = reader.ReadInt32();
        }
        public virtual void Save(BinaryWriter writer)
        {
            //FileStream file = new FileStream("1.txt", FileMode.Create, FileAccess.Write);
            //BinaryWriter writer = new BinaryWriter(file);                   
            writer.Write(Name);
            writer.Write(ManufacturerName);
            writer.Write(Model);
            writer.Write(Size);
            writer.Write(Price);
        }
    }
}


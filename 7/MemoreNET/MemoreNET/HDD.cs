using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MemoreNET
{
    class HDD:Memore
    {
        public int SizeP { get; set; }
        public int SpeedHDD { get; set; }

        public HDD()
            : this("HDD", "Kavasaki", "K20", 200, 200, 10, 50)
        {

        }

        public HDD(string Name, string ManufacturerName, string Model, int Size, int Price, int SizeP, int SpeedHDD)
            : base(Name, ManufacturerName, Model, Size, Price)
        {
            this.SizeP = SizeP;
            this.SpeedHDD = SpeedHDD;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("6.Size: {0}", SizeP);
            Console.WriteLine("7.Speed HDD: {0}", SpeedHDD);
        }
        public override void Load(BinaryReader reader, string Name)
        {
            base.Load(reader,  Name);
            SizeP = reader.ReadInt32();
            SpeedHDD = reader.ReadInt32();
        }
        public override void Save(BinaryWriter writer)
        {
            base.Save(writer);
            writer.Write(SizeP);
            writer.Write(SpeedHDD);
        }
    }
}

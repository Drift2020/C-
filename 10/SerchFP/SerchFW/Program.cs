using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace SerchFW
{
    class SerchFW
    {
        Dictionary<int, string> Files =
            new Dictionary<int, string>();
        Dictionary<int, string> Pap =
           new Dictionary<int, string>();

        private string disk;
        private string mask;
     
        public SerchFW()
        {

        }


        public void Print (int count=0)
        {
            Console.Clear();
            for(int i = count-50 ; i < count && i <= Files.Count+ Pap.Count; i++)
            {             
                if (Files.ContainsKey(i))
                {
                    Console.WriteLine("{0}. {1}",i, Files[i]);                 
                }   
                else if (Pap.ContainsKey(i))
                {
                    Console.WriteLine("{0}. {1}", i, Pap[i]);
                }
            }
        }
     
        private void Delete_F_and_D(int number)
        {
            if (Pap.ContainsKey(number))
            {
                Console.WriteLine(Files[number]);
                File.Delete(Files[number]);
                Files.Remove(number);
            }
            else if (Pap.ContainsKey(number))
            {
                Console.WriteLine(Pap[number]);
                Directory.Delete(Pap[number],true);
                Pap.Remove(number);
            }
        }

        public void Delete()
        {
            int key = 0;
            key= Int32.Parse(Console.ReadLine());
            switch (key)
            {
                case 1:
                    key = 0;
                    key = Int32.Parse(Console.ReadLine());

                    Delete_F_and_D(key);

                    break;
            }
        }

        public void AddParams(string disk, string mask)
        {
           
            this.disk = disk;
            this.mask = mask;
            
        }
        private void MascCorrect()
        {
            mask = mask.Replace(".", @"\.");
            // Заменяем ? на .
            mask = mask.Replace("?", ".");
            // Заменяем * на .*
            mask = mask.Replace("*", ".*");
            // Указываем, что требуется найти точное соответствие маске
            mask = "^" + mask + "$";
        }
        private void DiskCorrect()
        {
            if (disk[disk.Length - 1] != '\\')
                disk += '\\';
        }
        public void SearchFiles()
        {
            MascCorrect();
            DiskCorrect();

            DirectoryInfo di = new DirectoryInfo(disk);
            if (!di.Exists)
            {
                throw new Exception("Path incorrect!!!");
            }
            Regex regMask = new Regex(mask, RegexOptions.IgnoreCase);
            int count = 0;


            try
            {
                // Вызываем функцию поиска
                ulong Count = FindInFiles(di, regMask, ref count);
                Console.WriteLine("Всего обработано файлов: {0}.", Count);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

      

        private ulong FindInFiles(DirectoryInfo di, Regex regMask, ref int count)
        {
            ulong CountOfMatchFiles = 0;

            FileInfo[] fi = null;
            try
            {
                fi = di.GetFiles();
            }
            catch
            {
                return CountOfMatchFiles;
            }

            if (regMask.IsMatch(di.Name))
            {            
                ++CountOfMatchFiles;
                Pap.Add(count, di.FullName);
                count++;
            } 

            foreach (FileInfo f in fi)
            {               
                if (regMask.IsMatch(f.Name))
                {
                    // Увеличиваем счетчик
                    ++CountOfMatchFiles;
                    Files.Add(count, f.FullName);
                    count++;
                }

            }

           
            DirectoryInfo[] diSub = di.GetDirectories();
           
            foreach (DirectoryInfo diSubDir in diSub)
            {
                CountOfMatchFiles += FindInFiles(diSubDir, regMask, ref count);
            }


            // Возврат количества обработанных файлов
            return CountOfMatchFiles;
        }
    }
}

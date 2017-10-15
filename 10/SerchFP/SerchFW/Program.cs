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
    struct Date
    {
        public string FullName;
        public bool File_and_Direct;
    }
    class SerchFW
    {
        Dictionary<int, Date> Files =
            new Dictionary<int, Date>();
      
        private string disk;
        private string mask;
     
        public SerchFW()
        {

        }


        public void Print (int count=0)
        {
            Console.Clear();
            for(int i = count-50 ; i < count && i <= Files.Count; i++)
            {             
                if (Files.ContainsKey(i))
                {
                    Console.WriteLine("{0}. {1}",i, Files[i].FullName);                 
                }                 
            }
        }
        private void Delete_all()
        {
            for (int i = 0,size = Files.Count; i <= size; i++)
            {
                if (Files.ContainsKey(i))
                {
                    Console.WriteLine(Files[i].FullName);
                    if (Files[i].File_and_Direct)
                    {
                        File.Delete(Files[i].FullName);
                        Files.Remove(i);
                    }
                    else if (!Files[i].File_and_Direct)
                    {
                        Directory.Delete(Files[i].FullName, true);
                    }
                }
            }
        }
        private void Delete_F_and_D(int i)
        {
            if (Files.ContainsKey(i))
            {
                Console.WriteLine(Files[i].FullName);
                if (Files[i].File_and_Direct)
                {
                    File.Delete(Files[i].FullName);
                    Files.Remove(i);
                }
                else if(!Files[i].File_and_Direct)
                {
                    Directory.Delete(Files[i].FullName, true);
                }
            }
           
        }

        private void Delete_zone(int start,int end)
        {
            if (start < end && start >= 0 && end <= Files.Count)
            {
                for(int i=start;i<= end; i++)
                {
                    if (Files[i].File_and_Direct)
                    {
                        File.Delete(Files[i].FullName);
                        Files.Remove(i);
                    }
                    else if (!Files[i].File_and_Direct)
                    {
                        Directory.Delete(Files[i].FullName, true);
                    }
                }
            }
            else
            {
                if (start > end)
                    throw new Exception("ERROR, start more end.");
                else if (start == end)
                    throw new Exception("ERROR, start == end.");
                else if (start < 0)
                    throw new Exception("ERROR, start == 0.");
                else if (end > Files.Count)
                    throw new Exception("ERROR, end  > Files.Count.");
            }
        }
        public void Delete()
        {
            int key = 0;
            Console.Write("1. Delete f/d \n2. Delete all\n3. Delete zone\nPlese, enter variants: ");
            key = Int32.Parse(Console.ReadLine());
            switch (key)
            {
                case 1:
                    key = 0;
                    key = Int32.Parse(Console.ReadLine());

                    Delete_F_and_D(key);
                    break;
                case 2:
               
                    Delete_all();
                    break;
                case 3:
                    Console.Write("Plese enter start:");
                    int start = Int32.Parse(Console.ReadLine());
                    Console.Write("Plese enter end:");
                    int end = Int32.Parse(Console.ReadLine());
                    Delete_zone(start,end);
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

            if (regMask.IsMatch(di.Name)&& disk != di.FullName)
            {            
                ++CountOfMatchFiles;

                Date tempObj = new Date();
                tempObj.FullName = di.FullName;
                tempObj.File_and_Direct = false;

                Files.Add(count, tempObj);
                count++;
            } 

            foreach (FileInfo f in fi)
            {               
                if (regMask.IsMatch(f.Name))
                {
                    // Увеличиваем счетчик
                    ++CountOfMatchFiles;

                    Date tempObj = new Date();
                    tempObj.FullName = f.FullName;
                    tempObj.File_and_Direct = true;

                    Files.Add(count, tempObj);
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

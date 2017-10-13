using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace SerchFP
{
    class FileSearch
    {
        private string path;
        private string mask;
        private DateTime timeTo;
        private DateTime timePast;
        public FileSearch()
        {

        }

        private void TestCorrectValue(string path, string mask, DateTime timeTo, DateTime timePast)
        {
            if (timePast < timeTo)
            {
                throw new Exception("Error, date uncorrect");
            }
        }
        public void AddParams(string path, string mask, DateTime timeTo, DateTime timePast)
        {
            TestCorrectValue(path, mask, timeTo, timePast);
            this.path = path;
            this.mask = mask;
            this.timeTo = timeTo;
            this.timePast = timePast;
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
        private void PathCorrect()
        {
            if (path[path.Length - 1] != '\\')
                path += '\\';
        }
        public void SearchFiles()
        {
            MascCorrect();
            PathCorrect();

            DirectoryInfo di = new DirectoryInfo(path);
            if (!di.Exists)
            {
                throw new Exception("Path incorrect!!!");               
            }
            Regex regMask = new Regex(mask, RegexOptions.IgnoreCase);


            try
            {
                // Вызываем функцию поиска
                ulong Count = FindInFiles(timeTo, timePast, di, regMask);
                Console.WriteLine("Всего обработано файлов: {0}.", Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Save(FileInfo f)
        {

        }
        
        private ulong FindInFiles(DateTime timeTo, DateTime timePast, DirectoryInfo di, Regex regMask)
        {                 
            // Количество обработанных файлов
            ulong CountOfMatchFiles = 0;

            FileInfo[] fi = null;
            try
            {
                // Получаем список файлов
                fi = di.GetFiles();
            }
            catch
            {
                return CountOfMatchFiles;
            }

            // Перебираем список файлов
            foreach (FileInfo f in fi)
            {
               
                // Если файл соответствует маске
                if (regMask.IsMatch(f.Name) && File.GetLastWriteTime(f.FullName) <= timePast &&   File.GetLastWriteTime(f.DirectoryName) >=timeTo)
                {
                    // Увеличиваем счетчик
                    ++CountOfMatchFiles;
                    Console.WriteLine("File " + f.Name);
                    Save(f);
                }
            }

            // Получаем список подкаталогов
            DirectoryInfo[] diSub = di.GetDirectories();
            // Для каждого из них вызываем (рекурсивно)
            // эту же функцию поиска
            foreach (DirectoryInfo diSubDir in diSub)
                CountOfMatchFiles += FindInFiles(timeTo, timePast, diSubDir, regMask);

            // Возврат количества обработанных файлов
            return CountOfMatchFiles;
        }
    }
}

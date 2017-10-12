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
            if (timePast > timeTo)
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
        }
    }
}

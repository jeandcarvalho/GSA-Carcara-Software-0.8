using GSA_Carcara.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Class
{
    public class DirectoryDB : ISaveDBdirectory, IGetSavedDBdirectory
    {
        public void SaveFolderDB(string folder)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "\\dbInfo\\dbInfo.txt".ToString();
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(folder);
            }
        }

        public string GetFolderDB() 
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "\\dbInfo\\dbInfo.txt".ToString();
            using (StreamReader reader = new StreamReader(path))
            {
                string dir = reader.ReadLine();
                return dir;
            }
        }
    }
}

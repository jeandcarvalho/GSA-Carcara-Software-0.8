using GSA_Carcara.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Class
{
    public class DirectoryDBsave : ISaveDBdirectory
    {
        public void SaveFolderDB(string folder)
        {
            if (folder != null && folder == string.Empty)
            {
                string path = System.AppDomain.CurrentDomain.BaseDirectory + "\\dbInfo\\dbInfo.txt".ToString();
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(folder);
                }
            }
        }
    }
}

using GSA_Carcara.Class;
using GSA_Carcara.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Controls
{
    public class Log
    {
        public void LogHandler(string dir)
        {
            DirectoryInfo DBdirectoryInfo = new DirectoryInfo(dir);
            foreach (FileInfo file in DBdirectoryInfo.GetFiles())
            {
                bool verify = false;
                if (file.Extension.Contains(".log"))
                {
                    verify = new LogVerify().LogVerification(file.Name);
                }
                if (file.Extension.Contains(".log") && verify == true)
                {
                    new LogInsert().Insert(file);
                }
            }
        }
    }
}

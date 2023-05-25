using GSA_Carcara.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Class
{
    public class FilesHandler : IFilesHandler
    {
        ILogVerification logVerify = new LogVerify();
        IInsertLog logInsert = new LogInsert();
        ICsvVerification csvVerify = new CsvVerify();
        IInsertCsv csvInsert = new CsvInsert();
        public void CsvHandler(string dir)
        {
            DirectoryInfo DBdirectoryInfo = new DirectoryInfo(dir);
            foreach (FileInfo file in DBdirectoryInfo.GetFiles())
            {
                bool verify = false;
                if (file.Extension.Contains(".csv"))
                {
                    verify = csvVerify.CsvVerification(file.Name);
                }

                if (file.Extension.Contains(".csv") && verify == true)
                {
                    csvInsert.Insert(file);
                }
            }
        }
        public void LogHandler(string dir)
        {           
            DirectoryInfo DBdirectoryInfo = new DirectoryInfo(dir);
            foreach (FileInfo file in DBdirectoryInfo.GetFiles())
            {
                bool verify = false;
                if (file.Extension.Contains(".log"))
                {
                    verify = logVerify.LogVerification(file.Name);
                }
                if (file.Extension.Contains(".log") && verify == true)
                {
                    logInsert.Insert(file);
                }
            }
        }
    }
}

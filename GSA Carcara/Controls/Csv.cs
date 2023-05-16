using GSA_Carcara.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Controls
{
    public class Csv
    {
        public void CsvHandler(string dir)
        {
            DirectoryInfo DBdirectoryInfo = new DirectoryInfo(dir);
            foreach (FileInfo file in DBdirectoryInfo.GetFiles())
            {
                bool verify = false;
                if (file.Extension.Contains(".csv"))
                {
                    verify = new CsvVerify().CsvVerification(file.Name);
                }

                if (file.Extension.Contains(".csv") && verify == true)
                {
                    new CsvInsert().Insert(file);
                }
            }
        }
    }


}

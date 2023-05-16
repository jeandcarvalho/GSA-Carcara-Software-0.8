using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Interface
{
    interface IInsertCsv
    {
        void Insert(FileInfo file);
    }

    interface ICsvVerification
    {
        bool CsvVerification(string fileName);
    }


}

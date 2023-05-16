using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Interface
{
    interface IInsertLog
    {
        void Insert(FileInfo file);
    }

    interface ILogVerification
    {
        bool LogVerification(string fileName);
    }

}

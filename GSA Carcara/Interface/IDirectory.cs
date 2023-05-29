using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Interface
{
    interface IDirectorySelect
    {
        string SelectDirectory();
    }
    interface ISaveDBdirectory
    {
        void SaveFolderDB(string folder);
    }
    interface IGetDBdirectory
    {
       string GetFolderDB();
    }
}

using GSA_Carcara.Class;
using GSA_Carcara.Interface;
using GSA_Carcara.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSA_Carcara.Classes
{
    public class DBmongo : IUpdateMongo
    {
        ITimesStempHandler datetime = new TimeStempHandler();
        IStatusDatabase statusDB = new StatusDB();
        IDirectorySelect getDir = new Class.GetDirectory();
        ISaveDBdirectory DBdir = new DirectoryDB();
        IFilesHandler files = new FilesHandler();
        string DBfolder=null;
        string[] dirs=null;
        public void UpdateMongo(Label DatabaseStatus)
        {         
            try
            {  
                statusDB.SetStatusDatabase(DatabaseStatus);
                statusDB.DatabaseLoading(DatabaseStatus);  
                DBfolder = getDir.SelectDirectory();
                DBdir.SaveFolderDB(DBfolder);                                         //save db directory in local storage to aux other functions
                dirs = System.IO.Directory.GetDirectories(DBfolder);
                foreach (string dir in dirs)                                          //apply functions to all folders in DB
                {
                    files.CsvHandler(dir);                
                    files.LogHandler(dir);                
                }
                datetime.DeleteDateTimes();                                         //csv file and log file contain small differences regarding the number of document counts, this function removes non intersection data,                  
            }                                                                       //and also data that does not exist in both collections (Keeps data from the intersection of collections using DateTime comparassion for this)
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            statusDB.SetStatusDatabase(DatabaseStatus);
        }
    }
}

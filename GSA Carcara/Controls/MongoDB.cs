using GSA_Carcara.Class;
using GSA_Carcara.Controls;
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
    public class MongoDB
    {
        public void UpdateMongo(Label DatabaseStatus)
        {
            try
            {
                var Measurements = new GetCollections().CarCollection();
                var Ratings = new GetCollections().RatingCollection();
                new StatusDB().statusDatabaseLoading(DatabaseStatus);
                string DBfolder = new GetDirectory().SelectDirectory();
                new DirectoryDB().SaveFolderDB(DBfolder);                               //save db directory in local storage to aux other functions
                string[] dirs = Directory.GetDirectories(DBfolder);
                foreach (string dir in dirs)                                           //apply functions to all folders in DB
                {
                    new Csv().CsvHandler(dir);                
                    new Log().LogHandler(dir);                
                }
                new SyncCollections().DateTimeCheck(Measurements, Ratings);
                new StatusDB().statusDatabase(DatabaseStatus);                      //csv file and log file contain small differences regarding the number of document counts, this function removes non intersection data,    
            }                                                                       //and also data that does not exist in both collections (Keeps data from the intersection of collections using DateTime comparassion for this)
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}

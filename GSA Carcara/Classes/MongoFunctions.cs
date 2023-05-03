using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSA_Carcara.Classes
{
    public class MongoFunctions
    {
        public void AddUpdateMongo(Label DatabaseStatus)
        {
            try
            {
                string DBfolder;
                var Measurements = new MongoServices().CarCollection();
                var Ratings = new MongoServices().RatingCollection();
                new InterfaceSettings().statusDatabaseLoading(DatabaseStatus);
                DBfolder = new Directory_Handler().Directory_Finder();
                new FilesVerification().SaveDBdir(DBfolder);                             //save db directory in local storage to aux other functions
                string[] dirs = Directory.GetDirectories(DBfolder);
                foreach (string dir in dirs)                                           //apply functions to all folders in DB
                {
                    new FilesFunctions().CsvHandler(dir, Measurements);             //verify if data already exists in collection, if doesnt, read files and add data
                    new FilesFunctions().LogHandler(dir, Ratings);                 // ==
                }
                new SyncCollections().DateTimeCheck(Measurements, Ratings);       //csv file and log file contain small differences regarding the number of document counts, this function removes non intersection data,    
            }                                                                    //and also data that does not exist in both collections (Keeps data from the intersection of collections using DateTime comparassion for this)
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            new InterfaceSettings().statusDatabase(DatabaseStatus);
        }
    }
}

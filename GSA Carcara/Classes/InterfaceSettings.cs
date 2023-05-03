using GSA_Carcara.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GSA_Carcara.Classes
{
    public class InterfaceSettings
    {
        public void statusDatabase(System.Windows.Forms.Label status)
        {
            IMongoClient client = new MongoClient("mongodb://localhost:27017"); // conect to server
            var database = client.GetDatabase("Aquisitions"); // conect to database
            var vehicle = database.GetCollection<Vehicle>("Measurements");
            var filter = Builders<Vehicle>.Filter.Empty;
            var results = vehicle.Find(filter).CountDocuments();
            if (results == 0)  {   status.Text = "Not loaded"; status.ForeColor = System.Drawing.Color.Red;    }
            else  {  status.Text = "Loaded"; status.ForeColor = System.Drawing.Color.Green; }
        }

        public void statusDatabaseLoading(System.Windows.Forms.Label status)
        {
            status.Text = "Loading..";
        }

        public void ProgressBarUp(System.Windows.Forms.ProgressBar progressBar)
        {
            progressBar.Step = 20;
            progressBar.PerformStep();
        }

        public void ProgressBarDown(System.Windows.Forms.ProgressBar progressBar)
        {
            progressBar.Step = -1000;
            progressBar.PerformStep();
        }
    }
}

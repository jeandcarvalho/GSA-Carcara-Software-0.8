using GSA_Carcara.Interface;
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

namespace GSA_Carcara.Class
{
    public class DatabaseStatus : IStatusDatabase
    {
        public void StatusDatabase(System.Windows.Forms.Label status)
        {
            var collections = new GetCollections();
            var vehicle = collections.CarCollection();
            var filter = Builders<Vehicle>.Filter.Empty;
            var results = vehicle.Find(filter).CountDocuments();
            if (results == 0) { status.Text = "Not loaded"; status.ForeColor = System.Drawing.Color.Red; }
            else { status.Text = "Loaded"; status.ForeColor = System.Drawing.Color.Green; }
        }
    }   
}

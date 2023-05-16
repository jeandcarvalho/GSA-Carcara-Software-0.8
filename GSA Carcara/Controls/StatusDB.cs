using GSA_Carcara.Class;
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
    public class StatusDB
    {
        public void statusDatabase(System.Windows.Forms.Label status)
        {
           var statusDB = new StatusDatabase();
           statusDB.SetStatusDatabase(status);
        }

        public void statusDatabaseLoading(System.Windows.Forms.Label status)
        {
            status.Text = "Loading..";
        }

    }
}

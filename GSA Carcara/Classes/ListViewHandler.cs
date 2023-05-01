using GSA_Carcara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GSA_Carcara.Classes
{
    public class ListViewHandler
    {
        public void setListView(System.Windows.Forms.ListView listView1)
        {
            listView1.Items.Clear();
            listView1.Columns.Add("Time", 115);
            listView1.Columns.Add("Video Name", 185);
            listView1.Columns.Add("Wheel Angle", 75);
            listView1.Columns.Add("Vehicle Speed", 85);
            listView1.Columns.Add("Curves", 70);
            listView1.Columns.Add("Road Conditions", 90);
            listView1.Columns.Add("Traffic", 60);
            listView1.Columns.Add("Road Numbers", 90);
            listView1.Columns.Add("Road Type", 70);
            listView1.Columns.Add("Day/Night", 70);
            listView1.Columns.Add("Weather", 60);
            listView1.Columns.Add("Visibility", 90);
            listView1.Columns.Add("Driver", 60);
        }

        public void AddToListView(System.Windows.Forms.ListView listView1, List<Vehicle> CarFiltred, List<Rating> RatingFiltred)
        {
            for (int j = 0; j < CarFiltred.Count; j++)
            {
                var item = new ListViewItem(new[] { CarFiltred[j].TimeStemp.ToString(), CarFiltred[j].VideoName,
                                                     CarFiltred[j].WheelAngle.ToString(), CarFiltred[j].VehicleSpeed.ToString(),
                                                     CarFiltred[j].Curves, RatingFiltred[j].RoadConditions, RatingFiltred[j].Traffic,
                                                     RatingFiltred[j].RoadNumbers, RatingFiltred[j].RoadType, RatingFiltred[j].DayPeriod,
                                                     RatingFiltred[j].Weather, RatingFiltred[j].Visibility, RatingFiltred[j].Driver});
                listView1.View = View.Details;
                listView1.Items.Add(item);
            }
        }
    }
}

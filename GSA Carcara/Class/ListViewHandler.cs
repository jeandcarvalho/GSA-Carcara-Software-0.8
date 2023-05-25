using GSA_Carcara.Interface;
using GSA_Carcara.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GSA_Carcara.Classes
{
    public class ListViewHandler : IListView
    {
        public void setListView(System.Windows.Forms.ListView listView1)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("Result", 155);
        }

        public void AddToListView(System.Windows.Forms.ListView listView1, List<Vehicle> CarFiltred, List<Rating> RatingFiltred)
        {
            for (int j = 0; j < CarFiltred.Count; j++)
            {
                var item = new ListViewItem(new[] { CarFiltred[j].TimeStemp.ToString() });
                listView1.View = View.Details;
                listView1.Items.Add(item);
            }
        }
    }
}

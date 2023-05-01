using Amazon.Util.Internal;
using GSA_Carcara.Classes;
using GSA_Carcara.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GSA_Carcara
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public IMongoClient client = new MongoClient("mongodb://localhost:27017"); // conect to server
        public List<Vehicle> CarFiltred = new List<Vehicle>();
        public List<Rating> RatingFiltred = new List<Rating>();
        private void DBselect_Click(object sender, EventArgs e) // search and update data in mongodb
        {    
            var database = client.GetDatabase("Aquisitions"); // conect to database
            var Measurements = database.GetCollection<Vehicle>("Measurements");
            var Ratings = database.GetCollection<Rating>("Ratings");

            DBfolder.Text = new Directory_Handler().Directory_Finder();
            string[] dirs = Directory.GetDirectories(DBfolder.Text);
            foreach (string dir in dirs)                               //apply functions to all folders in DB
            {
                new FilesFunctions().CsvHandler(dir, Measurements);  //verify if data already exists in collection, if doesnt, read files and add data
                new FilesFunctions().LogHandler(dir, Ratings);       // ==
            }
            new SyncCollections().DateTimeCheck(Measurements, Ratings);   //csv file and log file contain small differences regarding the number of document counts, this function removes non intersection data,                                                                //and also data that does not exist in both collections (Keeps data from the intersection of collections using DateTime comparassion for this)
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var database = client.GetDatabase("Aquisitions"); // conect to database
            var Measurements = database.GetCollection<Vehicle>("Measurements");
            var Ratings = database.GetCollection<Rating>("Ratings");
            string[] CarFilters = { textBox1.Text, textBox2.Text, comboBox6.Text };                               //          
            string[] RatingFilters = { comboBox1.Text, comboBox2.Text, comboBox3.Text, comboBox4.Text,           //catch the selects filters in combobox's
                                       comboBox7.Text, comboBox8.Text, comboBox9.Text, comboBox10.Text };       //
            CarFiltred = new FiltersFunctions().CarFilter(Measurements, CarFilters);                         //apply filters in measurements collection, and get query data to a list
            RatingFiltred = new FiltersFunctions().RatingFilter(Ratings, RatingFilters);                    //apply filters in ratings collection, and get query data to a list
            new FiltersFunctions().ConcateFilters(CarFiltred, RatingFiltred);                              // this function finds intersection data between these two filtered lists, when finished, items.counts of both filtered  results are the same
            new ListViewHandler().setListView(listView1);                                           //Config listview
            new ListViewHandler().AddToListView(listView1, CarFiltred, RatingFiltred);             //add items to listview
        }
    }   
}

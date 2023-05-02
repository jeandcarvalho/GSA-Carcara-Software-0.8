using Amazon.Util.Internal;
using AxWMPLib;
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
            WindowState = FormWindowState.Maximized;
            new MediaPlayerControls().InitSettings(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3, axWindowsMediaPlayer4,
                                                   axWindowsMediaPlayer5, axWindowsMediaPlayer6);
            new InterfaceSettings().statusDatabase(DatabaseStatus);

        }
        // conect to server
        public List<Vehicle> CarFiltred = new List<Vehicle>();
        public List<Rating> RatingFiltred = new List<Rating>();
    
        private void openUpdateGSADatabaseMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string DBfolder;

                var Measurements = new MongoServices().CarCollection();
                var Ratings = new MongoServices().RatingCollection();
                new InterfaceSettings().statusDatabaseLoading(DatabaseStatus);
                DBfolder = new Directory_Handler().Directory_Finder();         
                string[] dirs = Directory.GetDirectories(DBfolder);
                foreach (string dir in dirs)                               //apply functions to all folders in DB
                {
                    
                    new FilesFunctions().CsvHandler(dir, Measurements);  //verify if data already exists in collection, if doesnt, read files and add data
                    new FilesFunctions().LogHandler(dir, Ratings);       // ==
                }
                
                new SyncCollections().DateTimeCheck(Measurements, Ratings);   //csv file and log file contain small differences regarding the number of document counts, this function removes non intersection data,    
            }                                                                    //and also data that does not exist in both collections (Keeps data from the intersection of collections using DateTime comparassion for this)
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            new InterfaceSettings().statusDatabase(DatabaseStatus);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                var Measurements = new MongoServices().CarCollection();
                var Ratings = new MongoServices().RatingCollection();
                string[] CarFilters = { textBox1.Text, textBox2.Text, comboBox6.Text };                               //          
                string[] RatingFilters = { comboBox1.Text, comboBox2.Text, comboBox3.Text, comboBox4.Text,           //catch the selects filters in combobox's
                                       comboBox7.Text, comboBox8.Text, comboBox9.Text, comboBox10.Text };       //
                CarFiltred = new FiltersFunctions().CarFilter(Measurements, CarFilters);                         //apply filters in measurements collection, and get query data to a list
                RatingFiltred = new FiltersFunctions().RatingFilter(Ratings, RatingFilters);                    //apply filters in ratings collection, and get query data to a list
                new FiltersFunctions().ConcateFilters(CarFiltred, RatingFiltred);                              // this function finds intersection data between these two filtered lists, when finished, items.counts of both filtered  results are the same
                new ListViewHandler().setListView(listView1);                                           //Config listview
                new ListViewHandler().AddToListView(listView1, CarFiltred, RatingFiltred);             //add items to listview
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            new MediaPlayerHandler().SetVideos(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3, axWindowsMediaPlayer4,
                                               axWindowsMediaPlayer5, axWindowsMediaPlayer6, CarFiltred, RatingFiltred, listView1);
        }

        
    }   
}

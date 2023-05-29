using GSA_Carcara.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Interface
{
    interface IInsertCsv
    {
        void InsertCsv(FileInfo file);
    }
    interface ICsvVerification
    {
        bool CsvVerification(string fileName);
    }
    interface IInsertLog
    {
        void InsertLog(FileInfo file);
    }
    interface ILogVerification
    {
        bool LogVerification(string fileName);
    }
    interface IFilesHandler
    {
        void LogHandler(string dir);
        void CsvHandler(string dir);
    }
    interface IClickedVideos
    {
        string FindClickedVideos(List<Vehicle> CarFiltred, DateTime moment);
        DateTime VideoStartDateTime(string videoName);
        double DefinePosition(DateTime moment, DateTime begin);
    }
}

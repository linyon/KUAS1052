using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YC.Models;

namespace YC
{
    class Program
    {
        static void setDBFilePath()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relative = @"..\..\App_Data\";
            string absolute = Path.GetFullPath(Path.Combine(baseDirectory, relative));
            AppDomain.CurrentDomain.SetData("DataDirectory", absolute);
        }

        static void Main(string[] args)
        {
            setDBFilePath();
            var import = new YC.Service.ImportService();
            var db = new YC.Repository.StationRepository();

            
            //var stations = import.FindStations(@"d:\THBRM.xml");

            //stations
            //    .ToList().ForEach(station =>
            //{
            //    db.Create(station);
            //});

            var stations = db.FindAllStations();

            ShowStation(stations);

            Console.ReadKey();
        }

        public static void ShowStation(List<Station> stations)
        {

            Console.WriteLine(string.Format("共收到{0}筆監測站的資料", stations.Count));
            stations.ForEach(x =>
            {
                Console.WriteLine(string.Format("站點名稱：{0},地址:{1}", x.ObservatoryName, x.LocationAddress));


            });


        }
    }
}

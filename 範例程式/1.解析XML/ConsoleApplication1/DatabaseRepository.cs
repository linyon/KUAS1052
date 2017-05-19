using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DatabaseRepository
    {
        private const string _connectionString  = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GitHub\0324\範例程式\解析XML\ConsoleApplication1\App_Data\Water.mdf;Integrated Security=True";


        public void CreateStation(Models.Station station)
        {
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT        INTO    Station(ID, LocationAddress, ObservatoryName, LocationByTWD67, CreateTime)
VALUES          ('{0}','{1}','{2}','{3}','{4}')
", station.ID, station.LocationAddress, station.ObservatoryName, station.LocationByTWD67, station.CreateTime.ToString("yyyy/MM/dd"));

            command.ExecuteNonQuery();


            connection.Close();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YC.Repository
{
    public class RecordRepository
    {
        private string _connectionString= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\WaterDB.mdf;Integrated Security=True";
 


        public void Create(List<Models.Record> records)
        {
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            foreach (var record in records)
            {
                var command = new System.Data.SqlClient.SqlCommand("", connection);
                command.CommandText = string.Format(@"
INSERT        INTO    Record(StationID,WaterLevel,RecordTime,CreateTime)
VALUES          (N'{0}',{1},N'{2}',N'{3}')
", record.StationID, record.WaterLevel, record.RecordTime.ToString("yyyy/MM/dd HH:mm"), record.CreateTime.ToString("yyyy/MM/dd HH:mm"));

                command.ExecuteNonQuery();
            }



            connection.Close();
        }


//        public List<Models.Station> FindAllStations()
//        {
//            var result = new List<Models.Station>();
//            var connection = new System.Data.SqlClient.SqlConnection(_connectionString);
//            connection.Open();
//            var command = new System.Data.SqlClient.SqlCommand("", connection);
//            command.CommandText = @"
//Select * from Station";
//            var reader = command.ExecuteReader();

//            while (reader.Read())
//            {
//                Models.Station item = new Models.Station();
//                item.ID = reader["ID"].ToString();
//                item.LocationAddress = reader["LocationAddress"].ToString();
//                item.ObservatoryName = reader["ObservatoryName"].ToString();
//                item.LocationByTWD67 = reader["LocationByTWD67"].ToString();
//                item.CreateTime = DateTime.Parse(reader["CreateTime"].ToString());
//                result.Add(item);
//            }
//            connection.Close();


//            return result;
//        }



    }
}

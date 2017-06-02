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


        public bool IsExist(Models.Record record)
        {
            var id = record.StationID;
            var datetime = record.RecordTime;
            
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            
                var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
Select count(*) from Record
where StationID='{0}' and RecordTime='{1}'
", record.StationID, record.RecordTime.ToString("yyyy/MM/dd HH:mm"));


            connection.Open();
            int countResult = int.Parse(command.ExecuteScalar().ToString());
            connection.Close();



            return countResult > 0;
        }



    }
}

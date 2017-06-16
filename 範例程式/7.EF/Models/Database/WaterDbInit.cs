using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YC.Database
{
    public class WaterDbInit:System.Data.Entity.DropCreateDatabaseAlways<WaterDbContext>
    {
        protected override void Seed(WaterDbContext context)
        {
            Service.ImportService import = new Service.ImportService();
            var stations = import.FindStations(@"D:\THBRM.xml");

            stations.ForEach(station =>
            {
                context.StationTable.Add(station);
            });
            context.SaveChanges();

        }

    }
}

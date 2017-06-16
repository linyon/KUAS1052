using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YC.Database
{
    public class WaterDbContext:System.Data.Entity.DbContext
    {
        static WaterDbContext()
        {
            System.Data.Entity.Database.SetInitializer<WaterDbContext>(new WaterDbInit());
        }
        public WaterDbContext():base("EFConnection")
        {

        }

        public System.Data.Entity.IDbSet<Models.Station> StationTable { get; set; }
        public System.Data.Entity.IDbSet<Models.Group> GroupTable { get; set; }
        public System.Data.Entity.IDbSet<Models.Record> RecordTable { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YC.Models
{
    public class Station
    {
        public string ID { get; set; }
        public string LocationAddress { get; set; }
        public string ObservatoryName { get; set; }
        public string LocationByTWD67 { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastRecordTime { get; set; }
        public double LastRecordWaterLevel { get; set; }






    }
}

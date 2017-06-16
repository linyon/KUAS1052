using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YC.Models
{
    public class Record
    {

        [System.ComponentModel.DataAnnotations.Key]
        public int ID { get; set; }
        public string StationID { get; set; }
        public double WaterLevel { get; set; }
        public DateTime RecordTime { get; set; }
        public DateTime CreateTime { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("StationID")]
        public virtual Station Station { get; set; }
    }
}

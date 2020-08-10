using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Models
{
    public class CollectionPoint
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Location { get; set; }
        public string CollectionTime { get; set; } // 9:30AM, 11:00AM

        public CollectionPoint() { }
        public CollectionPoint(string Location, string CollectionTime)
        {
            this.Location = Location;
            this.CollectionTime = CollectionTime;
        }
    }
}

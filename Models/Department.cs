using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Models
{
    public class Department
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int PhoneNo { get; set; }
        public int? FaxNo { get; set; }
        [Required]
        public int RepId { get; set; }
        [Required]
        public int HeadId { get; set; }
        [Required]
        public int CollectionPointId { get; set; }

        // FKs
        [ForeignKey("RepId")]
        public Employee Rep { get; set; }
        [ForeignKey("HeadId")]
        public Employee Head { get; set; }
        [ForeignKey("CollectionPointId")]
        public CollectionPoint CollectionPoint { get; set; }
    }
}

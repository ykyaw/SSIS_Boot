using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Models
{
    public class Supplier
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ContactPersonName { get; set; }
        [Required]
        public int PhoneNo { get; set; }
        public int? FaxNo { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string GstRegNo { get; set; }
    }
}

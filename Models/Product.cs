using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Models
{
    public class Product
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CategoryId { get; set; }
        [Required]
        public int ReorderLvl { get; set; }
        [Required]
        public int ReorderQty { get; set; }
        [Required]
        public string Uom { get; set; }

        // FKs
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}

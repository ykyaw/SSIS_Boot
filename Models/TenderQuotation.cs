using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Models
{
    public class TenderQuotation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string SupplierId { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string ProductId { get; set; }
        [Required]
        public string PricePerUom { get; set; }
        public int? Rank { get ; set; }

        // FKs
        [ForeignKey("SupplierID")]
        public Supplier Supplier { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }
    }
}

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
        public string SupplierId { get; set; }
        public int Year { get; set; }
        public string ProductId { get; set; }
        public string PricePerUom { get; set; }
        public int? Rank { get ; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Product Product { get; set; }
    }
}

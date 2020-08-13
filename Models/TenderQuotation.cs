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
        public double unitprice { get; set; }
        public string uom { get; set; }
        public int? Rank { get ; set; }
        public  Supplier Supplier { get; set; }
        public  Product Product { get; set; }

        public TenderQuotation() { }

        public TenderQuotation(string SupplierId, int Year, string ProductId, string uom, int? Rank)
        {
            this.SupplierId = SupplierId;
            this.Year = Year;
            this.ProductId = ProductId;
            this.uom = uom;
            this.Rank = Rank;
        }
    }
}

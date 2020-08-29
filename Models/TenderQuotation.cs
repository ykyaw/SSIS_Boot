using System.ComponentModel.DataAnnotations.Schema;


namespace SSIS_BOOT.Models
{
    public class TenderQuotation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SupplierId { get; set; }
        public int Year { get; set; }
        public string ProductId { get; set; }
        public double Unitprice { get; set; }
        public string Uom { get; set; }
        public int? Rank { get ; set; }
        public  Supplier Supplier { get; set; }
        public  Product Product { get; set; }
        public TenderQuotation() { }
        public TenderQuotation(string SupplierId, int Year, string ProductId, double Unitprice, string Uom, int? Rank)
        {
            this.SupplierId = SupplierId;
            this.Year = Year;
            this.ProductId = ProductId;
            this.Uom = Uom;
            this.Unitprice = Unitprice;
            this.Rank = Rank;
        }
    }
}

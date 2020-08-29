using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SSIS_BOOT.Models
{
    public class Product
    {
        [Key]
        public string Id { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public int ReorderLvl { get; set; }
        public int ReorderQty { get; set; }
        public string Uom { get; set; }
        public  Category Category { get; set; }
        public ICollection<TenderQuotation> TenderQuotation { get; set; }
        public Product() { }
        public Product(string Id, string Description, int CategoryId)
        {
            this.Id = Id;
            this.Description = Description;
            this.CategoryId = CategoryId;
        }
        public Product(string Id, string Description, int CategoryId, int ReorderLvl, int ReorderQty, string Uom)
        {
            this.Id = Id;
            this.Description = Description;
            this.CategoryId = CategoryId;
            this.ReorderLvl = ReorderLvl;
            this.ReorderQty = ReorderQty;
            this.Uom = Uom;
        }
    }
}

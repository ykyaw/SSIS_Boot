using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public int ReorderLvl { get; set; }
        public int ReorderQty { get; set; }
        public string Uom { get; set; }
        public  Category Category { get; set; }
        public Product() { }
        public Product(string Id, string Description, int CategoryId)
        {
            this.Id = Id;
            this.Description = Description;
            this.CategoryId = CategoryId;
        }
    }
}

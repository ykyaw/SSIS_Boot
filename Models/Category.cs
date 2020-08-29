using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace SSIS_BOOT.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string BinNo { get; set; }
        public Category() { }
        public Category(string Name, string BinNo)
        {
            this.Name = Name;
            this.BinNo = BinNo;
        }
        public  List<Product> Products { get; set; }
    }
}

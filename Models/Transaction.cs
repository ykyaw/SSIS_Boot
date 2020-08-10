using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Models
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string ProductID { get; set; }
        [Required]
        public long Date { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Qty { get; set; }
        public int Balance { get; set; }
        [Required]
        public int UpdatedByEmpId { get; set; }
        public string RefCode { get; set; }

        // FKs
        [ForeignKey("ProductID")]
        public Product Product { get; set; }
        [ForeignKey("UpdatedByEmpId")]
        public Employee UpdatedByEmp { get; set; }
    }
}

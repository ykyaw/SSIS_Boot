using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Models
{
    public class AdjustmentVoucherDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string AdjustmentVoucherId { get; set; }
        [Required]
        public string ProductId { get; set; }
        [Required]
        public int QtyAdjusted { get; set; }
        public double TotalPrice { get; set; }
        [Required]
        public string Reason { get; set; }

        // FKs
        [ForeignKey("AdjustmentVoucherId")]
        public AdjustmentVoucher AdjustmentVoucher { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}

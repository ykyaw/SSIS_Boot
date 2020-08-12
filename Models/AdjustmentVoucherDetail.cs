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
        public string AdjustmentVoucherId { get; set; }
        public string ProductId { get; set; }
        public int QtyAdjusted { get; set; }
        public double TotalPrice { get; set; }

        public  AdjustmentVoucher AdjustmentVoucher { get; set; }
        public  Product Product { get; set; }



       //CONSTRUCTOR
        public AdjustmentVoucherDetail() { }
        public AdjustmentVoucherDetail(string AdjustmentVoucherId, string ProductId, int QtyAdjusted, double TotalPrice, string Reason)
        {
            this.AdjustmentVoucherId = AdjustmentVoucherId;
            this.ProductId = ProductId;
            this.QtyAdjusted = QtyAdjusted;
            this.TotalPrice = TotalPrice;
        }

    }
}

using System.ComponentModel.DataAnnotations.Schema;


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
        public double Unitprice { get; set; }
        public string Reason { get; set; }
        public  AdjustmentVoucher AdjustmentVoucher { get; set; }
        public  Product Product { get; set; }
        public AdjustmentVoucherDetail() { }
        public AdjustmentVoucherDetail(string AdjustmentVoucherId, string ProductId, int QtyAdjusted, double Unitprice, double TotalPrice, string Reason)
        {
            this.AdjustmentVoucherId = AdjustmentVoucherId;
            this.ProductId = ProductId;
            this.QtyAdjusted = QtyAdjusted;
            this.Unitprice = Unitprice;
            this.TotalPrice = TotalPrice;
            this.Reason = Reason;
        }

    }
}

using System.ComponentModel.DataAnnotations.Schema;


namespace SSIS_BOOT.Models
{
    public class PurchaseOrderDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? PurchaseOrderId { get; set; }
        public int? PurchaseRequestDetailId { get; set; }
        public string ProductId { get; set; }
        public int QtyPurchased { get; set; }
        public int? QtyReceived { get; set; }
        public int? ReceivedByClerkId { get; set; }
        public long? ReceivedDate { get; set; }
        public double TotalPrice { get; set; }
        public string? SupplierDeliveryNo { get; set; }
        public string? Remark { get; set; }
        public string Status { get; set; }
        public Employee ReceivedByClerk { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public  PurchaseRequestDetail PurchaseRequestDetail { get; set; }
        public  Product Product { get; set; }
        public PurchaseOrderDetail() { }
        public PurchaseOrderDetail(int? PurchaseOrderId, int? PurchaseRequestDetailId, string ProductId, int QtyPurchased, int? QtyReceived,
            double TotalPrice) {
            this.PurchaseOrderId = PurchaseOrderId;
            this.PurchaseRequestDetailId = PurchaseRequestDetailId;
            this.ProductId = ProductId;
            this.QtyPurchased = QtyPurchased;
            this.QtyReceived = QtyReceived;
            this.TotalPrice = TotalPrice;
        }
        public PurchaseOrderDetail(int? PurchaseOrderId, int? PurchaseRequestDetailId, string ProductId, int QtyPurchased, int? QtyReceived, 
            double TotalPrice, string? SupplierDeliveryNo, string? Remark, string Status) {
            this.PurchaseOrderId = PurchaseOrderId;
            this.PurchaseRequestDetailId = PurchaseRequestDetailId;
            this.ProductId = ProductId;
            this.QtyPurchased = QtyPurchased;
            this.QtyReceived = QtyReceived;
            this.TotalPrice = TotalPrice;
            this.SupplierDeliveryNo = SupplierDeliveryNo;
            this.Remark = Remark;
            this.Status = Status;
        }
    }
}

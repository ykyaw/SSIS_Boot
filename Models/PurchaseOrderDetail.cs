using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
        public double TotalPrice { get; set; }
        public int? SupplierDeliveryNo { get; set; }
        public string? Remark { get; set; }
        public  PurchaseOrder PurchaseOrder { get; set; }
        public  PurchaseRequestDetail PurchaseRequestDetail { get; set; }
        public  Product Product { get; set; }

        //constructor
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
            double TotalPrice, int? SupplierDeliveryNo, string? Remark) {
            this.PurchaseOrderId = PurchaseOrderId;
            this.PurchaseRequestDetailId = PurchaseRequestDetailId;
            this.ProductId = ProductId;
            this.QtyPurchased = QtyPurchased;
            this.QtyReceived = QtyReceived;
            this.TotalPrice = TotalPrice;
            this.SupplierDeliveryNo = SupplierDeliveryNo;
            this.Remark = Remark;
        }
    }
}

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
        public string Remark { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual PurchaseRequestDetail PurchaseRequestDetail { get; set; }
        public virtual Product Product { get; set; }
    }
}

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
        [Required]
        public int PurchaseOrderId { get; set; }
        [Required]
        public int PurchaseRequestDetailId { get; set; }
        [Required]
        public string ProductId { get; set; }
        [Required]
        public int QtyPurchased { get; set; }
        public int? QtyReceived { get; set; }
        public double TotalPrice { get; set; }
        public int? SupplierDeliveryNo { get; set; }
        public string Remark { get; set; }

        // FKs
        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder PurchaseOrder { get; set; }
        [ForeignKey("PurchaseRequestDetailId")]
        public PurchaseRequestDetail PurchaseRequestDetail { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}

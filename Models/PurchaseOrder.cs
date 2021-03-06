using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace SSIS_BOOT.Models
{
    public class PurchaseOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SupplierId { get; set; }
        public double TotalPrice { get; set; }
        public int OrderedByClerkId { get; set; }
        public long? OrderedDate { get; set; }
        public long SupplyByDate { get; set; }
        public int? ApprovedBySupId { get; set; }
        public string Status { get; set; }
        public int? CollectionPointId { get; set; }
        public CollectionPoint CollectionPoint { get; set; }
        public  Supplier Supplier { get; set; }
        public  Employee OrderedByClerk { get; set; }
        public  Employee ApprovedBySup { get; set; }
        public  List<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public PurchaseOrder() { }
        public PurchaseOrder(string SupplierId, double TotalPrice, int OrderedByClerkId, long? OrderedDate, long SupplyByDate)
        {
            this.SupplierId = SupplierId;
            this.TotalPrice = TotalPrice;
            this.OrderedByClerkId = OrderedByClerkId;
            this.OrderedDate = OrderedDate;
            this.SupplyByDate = SupplyByDate;
            this.CollectionPointId = 1;//CollectionPointId=1 is store, to get location: CollectionPointId.Location
        }
        public PurchaseOrder(string SupplierId, double TotalPrice, int OrderedByClerkId, long? OrderedDate, long SupplyByDate, int? ApprovedBySupId,
            string Status)
        {
            this.SupplierId = SupplierId;
            this.TotalPrice = TotalPrice;
            this.OrderedByClerkId = OrderedByClerkId;
            this.OrderedDate = OrderedDate;
            this.SupplyByDate = SupplyByDate;
            this.ApprovedBySupId = ApprovedBySupId;
            CollectionPointId = 1;//CollectionPointId=1 is store, to get location: CollectionPointId.Location
        }
        public PurchaseOrder(string SupplierId, double TotalPrice, int OrderedByClerkId, long? OrderedDate, long SupplyByDate, int? ApprovedBySupId)
        {
            this.SupplierId = SupplierId;
            this.TotalPrice = TotalPrice;
            this.OrderedByClerkId = OrderedByClerkId;
            this.OrderedDate = OrderedDate;
            this.SupplyByDate = SupplyByDate;
            this.ApprovedBySupId = ApprovedBySupId;
            CollectionPointId = 1;//CollectionPointId=1 is store, to get location: CollectionPointId.Location
        }
    }
}

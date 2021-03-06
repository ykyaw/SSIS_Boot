using System.ComponentModel.DataAnnotations.Schema;


namespace SSIS_BOOT.Models
{
    public class RequisitionDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? RequisitionId { get; set; }
        public string? ProductId { get; set; }
        public int QtyNeeded { get; set; }
        public int? QtyDisbursed { get; set; }
        public int? QtyReceived { get; set; }
        public string? DisburseRemark { get; set; }
        public string? RepRemark { get; set; }
        public string? ClerkRemark { get; set; }
        public int? RetrievalId { get; set; }
        public  Requisition Requisition { get; set; }
        public  Product Product { get; set; }
        public  Retrieval Retrieval { get; set; }
        public RequisitionDetail() { }
        public RequisitionDetail(int RequisitionId, string ProductId)
        {
            this.RequisitionId = RequisitionId;
            this.ProductId = ProductId;
        }
        public RequisitionDetail(int RequisitionId, string ProductId, int QtyNeeded) { 
            this.RequisitionId = RequisitionId;
            this.ProductId = ProductId;
            this.QtyNeeded = QtyNeeded;
        }
        public RequisitionDetail(int RequisitionId, string ProductId, int QtyNeeded, int? QtyDisbursed, int? QtyReceived, 
            string? DisburseRemark, string? RepRemark, string? ClerkRemark,int? RetrievalId)
        {
            this.RequisitionId = RequisitionId;
            this.ProductId = ProductId;
            this.QtyNeeded = QtyNeeded;
            this.QtyDisbursed = QtyDisbursed;
            this.QtyReceived = QtyReceived;
            this.DisburseRemark = DisburseRemark;
            this.RepRemark = RepRemark;
            this.ClerkRemark = ClerkRemark;
            this.RetrievalId = RetrievalId;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Models
{
    public class PurchaseRequestDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long PurchaseRequestId { get; set; } //timestamp
        public int CreatedByClerkId { get; set; }
        public string ProductId { get; set; }
        public string SupplierId { get; set; }
        public int CurrentStock { get; set; }
        public int ReorderQty { get; set; }
        public string? VenderQuote { get; set; } //Can't submit if null
        public double TotalPrice { get; set; }
        public long? SubmitDate { get; set; }
        public long? ApprovedDate { get; set; }
        public int? ApprovedBySupId { get; set; }
        public string Status { get; set; }
        public string? Remarks { get; set; }

        public Product Product { get; set; }
        public  Employee CreatedByClerk { get; set; }
        public  Supplier Supplier { get; set; }
        public  Employee ApprovedBySup { get; set; }

        public PurchaseRequestDetail() { }

        public PurchaseRequestDetail(long PurchaseRequestId, int CreatedByClerkId, string ProductId, string SupplierId, int CurrentStock,
            int ReorderQty, string? VenderQuote, double TotalPrice, long? SubmitDate, string Status)
        {
            this.PurchaseRequestId = PurchaseRequestId;
            this.CreatedByClerkId = CreatedByClerkId;
            this.ProductId = ProductId;
            this.SupplierId = SupplierId;
            this.CurrentStock = CurrentStock;
            this.ReorderQty = ReorderQty;
            this.VenderQuote = VenderQuote;
            this.TotalPrice = TotalPrice;
            this.SubmitDate = SubmitDate;
            this.Status = Status;
            
        }
        public PurchaseRequestDetail(long PurchaseRequestId, int CreatedByClerkId, string ProductId, string SupplierId, int CurrentStock,
            int ReorderQty, string? VenderQuote, double TotalPrice, long? SubmitDate, long? ApprovedDate, int? ApprovedBySupId, 
            string Status, string? Remarks) {
            this.PurchaseRequestId = PurchaseRequestId;
            this.CreatedByClerkId = CreatedByClerkId;
            this.ProductId = ProductId;
            this.SupplierId = SupplierId;
            this.CurrentStock = CurrentStock;
            this.ReorderQty = ReorderQty;
            this.VenderQuote = VenderQuote;
            this.TotalPrice = TotalPrice;
            this.SubmitDate = SubmitDate;
            this.ApprovedDate = ApprovedDate;
            this.ApprovedBySupId = ApprovedBySupId;
            this.Status = Status;
            this.Remarks = Remarks;
        }
    }
}

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
        public int PurchaseRequestId { get; set; }
        public int CreatedByClerkId { get; set; }
        public string ProductId { get; set; }
        public string SupplierId { get; set; }
        public int CurrentStock { get; set; }
        public int ReorderQty { get; set; }
        public string VenderQuote { get; set; } //Can't submit if null
        public double TotalPrice { get; set; }
        public long? SubmitDate { get; set; }
        public long? ApprovedDate { get; set; }
        public int? ApprovedBySupId { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }

        public  Employee CreatedByClerk { get; set; }
        public  Supplier Supplier { get; set; }
        public  Employee ApprovedBySup { get; set; }

    }
}

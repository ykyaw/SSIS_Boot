using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Models
{
    public class RequisitionDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? RequisitionId { get; set; }
        public string? ProductId { get; set; }
        public int QtyNeeded { get; set; }
        public int QtyDisbursed { get; set; }
        public int QtyReceived { get; set; }
        public string DisburseRemark { get; set; }
        public string RepRemark { get; set; }
        public string ClerkRemark { get; set; }
        public virtual Requisition Requisition { get; set; }
        public virtual Product Product { get; set; }
        public virtual Retrieval Retrieval { get; set; }
        public RequisitionDetail() { }
        public RequisitionDetail(int RequisitionId, string ProductId)
        {
            this.RequisitionId = RequisitionId;
            this.ProductId = ProductId;
        }
    }
}
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
        [Required]
        public int RequisitionId { get; set; }
        [Required]
        public string ProductId { get; set; }
        public int QtyNeeded { get; set; }
        public int QtyDisbursed { get; set; }
        public int QtyReceived { get; set; }
        public string DisburseRemark { get; set; }
        public string RepRemark { get; set; }
        public string ClerkRemark { get; set; }

        // FKs
        [ForeignKey("RequisitionId")]
        public Requisition Requisition { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
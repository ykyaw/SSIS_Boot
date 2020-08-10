using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Models
{
    public class Requisition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string DepartmentId { get; set; }
        [Required]
        public int ReqByEmpId { get; set; }
        public int? ApprovedById { get; set; }
        public int? ProcessedByClerkId { get; set; }
        public long CreatedDate { get; set; }
        [Required]
        public string Status { get; set; }
        public int? CollectionPointId { get; set; }
        public long? CollectionDate { get; set; }
        public int? ReceivedByRepId { get; set; }
        public long? ReceivedDate { get; set; }
        public int? AckByClerkId { get; set; }
        public long? AckDate { get; set; }

        // FKs
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        [ForeignKey("ReqByEmpId")]
        public Employee ReqByEmp { get; set; }
        [ForeignKey("ApprovedById")]
        public Employee ApprovedBy { get; set; }
        [ForeignKey("ProcessedByClerkId")]
        public Employee ProcessedByClerk { get; set; }
        [ForeignKey("CollectionPointId")]
        public CollectionPoint CollectionPoint { get; set; }
        [ForeignKey("ReceivedByRepId")]
        public Employee ReceivedByRep { get; set; }
        [ForeignKey("AckByClerkId")]
        public Employee AckByClerk { get; set; }

        //public virtual List<RequisitionDetail> RequisitionDetails { get; set; }
    }
}

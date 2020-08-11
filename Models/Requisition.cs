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
        public string? DepartmentId { get; set; }
        [ForeignKey("ReqByEmp")]
        public int ReqByEmpId { get; set; }
        [ForeignKey("ApprovedBy")]
        public int? ApprovedById { get; set; }
        public string? Remarks { get; set; }

        [ForeignKey("ProcessedByClerk")]
        public int? ProcessedByClerkId { get; set; }
        public long CreatedDate { get; set; }
        public string Status { get; set; }
        public int? CollectionPointId { get; set; }
        public long? CollectionDate { get; set; }
        [ForeignKey("ReceivedByRep")]
        public int? ReceivedByRepId { get; set; }
        public long? ReceivedDate { get; set; }
        [ForeignKey("AckByClerk")]
        public int? AckByClerkId { get; set; }
        public long? AckDate { get; set; }
        public virtual Department Department { get; set; }
        public virtual Employee ReqByEmp { get; set; }
        public virtual Employee ApprovedBy { get; set; }
        public virtual Employee ProcessedByClerk { get; set; }
        public virtual Employee ReceivedByRep { get; set; }
        public virtual Employee AckByClerk { get; set; }
        public virtual CollectionPoint CollectionPoint { get; set; }
        public virtual List<RequisitionDetail> RequisitionDetails { get; set; }

        public Requisition() { }

        public Requisition(string DepartmentId, int ReqByEmpId, string Status)
        {
            this.DepartmentId = DepartmentId;
            this.ReqByEmpId = ReqByEmpId;
            this.Status = Status;
        }
        public Requisition(string DepartmentId, int ReqByEmpId, int ApprovedById, int ProcessedByClerkId)
        {
            this.DepartmentId = DepartmentId;
            this.ReqByEmpId = ReqByEmpId;
            this.ApprovedById = ApprovedById;
            this.ProcessedByClerkId = ProcessedByClerkId;
        }
        public Requisition(string DepartmentId, int ReqByEmpId, int ApprovedById, string? Remarks,int ProcessedByClerkId, long CreatedDate, string Status,
            int? CollectionPointId, long? CollectionDate, int? ReceivedByRepId, long? ReceivedDate, int? AckByClerkId, long? AckDate)
        {
            this.DepartmentId = DepartmentId;
            this.ReqByEmpId = ReqByEmpId;
            this.ApprovedById = ApprovedById;
            this.ProcessedByClerkId = ProcessedByClerkId;
            this.CreatedDate = CreatedDate;
            this.Status = Status;
            this.CollectionPointId = CollectionPointId;
            this.CollectionDate = CollectionDate;
            this.ReceivedByRepId = ReceivedByRepId;
            this.ReceivedDate = ReceivedDate;
            this.AckByClerkId = AckByClerkId;
            this.AckDate = AckDate;
        }
    }
}

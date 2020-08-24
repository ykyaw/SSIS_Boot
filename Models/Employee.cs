using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace SSIS_BOOT.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PhoneNo { get; set; }
        public string? DepartmentId { get; set; }
        public int? ManagerId { get; set; }
        public long? DelegateFromDate { get; set; }
        public long? DelegateToDate { get; set; }

        public string Role { get; set; }

        public  Department Department { get; set; }
 

        /*One manager multiple employee relationship*/
        public  Employee Manager { get; set; }

        public  ICollection<Employee> Employees { get; set; }



        /* The InverseProperty attribute is used when two entities have more than one relationship, in this case is Requsition and Employee */

        //[InverseProperty("ReqByEmp")]
        //public  ICollection<Requisition> Requestedrequsition { get; set; }

        //[InverseProperty("ApprovedBy")]
        //public  ICollection<Requisition> Approvedrequsition { get; set; }

        //[InverseProperty("ProcessedByClerk")]
        //public  ICollection<Requisition> Processedrequsition { get; set; }

        //[InverseProperty("ReceivedByRep")]
        //public  ICollection<Requisition> Receivedrequsitions { get; set; }

        //[InverseProperty("AckByClerk")]
        //public  ICollection<Requisition> Acknowledgedrequsition { get; set; }

        //public  ICollection<Transaction> Transactions { get; set; }

        public Employee() { }
        public Employee(string Name, string Email, string Password,string DepartmentId,string Role )
        {
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
            this.DepartmentId = DepartmentId;
            this.Role = Role;
            
        }
    }
}

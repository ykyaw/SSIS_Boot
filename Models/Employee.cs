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
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int PhoneNo { get; set; }
        [Required]
        public string DepartmentId { get; set; }
        [Required]
        public int ManagerId { get; set; }
        public long? DelegateFromDate { get; set; }
        public long? DelegateToDate { get; set; }

        // FKs
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        [ForeignKey("ManagerId")]
        public Employee Manager { get; set; }
    }
}

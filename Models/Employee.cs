using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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
        public  Employee Manager { get; set; }
        public  ICollection<Employee> Employees { get; set; }
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

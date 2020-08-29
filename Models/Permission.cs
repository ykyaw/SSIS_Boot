using System.ComponentModel.DataAnnotations.Schema;


namespace SSIS_BOOT.Models
{
    public class Permission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public string EmployeeRole { get; set; }
        public string UrlPath { get; set; } 
        public Permission() { }
        public Permission( string Description, string EmployeeRole,string UrlPath)
        {
            this.Description = Description;
            this.EmployeeRole = EmployeeRole;
            this.UrlPath = UrlPath;
        }
    }
}

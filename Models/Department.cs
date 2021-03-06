using System.Collections.Generic;


namespace SSIS_BOOT.Models
{
    public class Department
    { 
        public string Id { get; set; }
        public string Name { get; set; }
        public int PhoneNo { get; set; }
        public int? FaxNo { get; set; }
        public int? RepId { get; set; }    
        public int? HeadId { get; set; }
        public int? CollectionPointId { get; set; }
        public Department(){}
        public Department(string Id, string name, int PhoneNo)
        {
            this.Id = Id ;
            this.Name = name;
            this.PhoneNo = PhoneNo;
        }     
        public  CollectionPoint CollectionPoint { get; set; }
        public  List<Employee> AllEmp { get; set; }
    }
}

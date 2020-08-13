using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Models
{
    public class Supplier
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ContactPersonName { get; set; }
        public int PhoneNo { get; set; }
        public int? FaxNo { get; set; }
        public string Address { get; set; }
        public string? Email { get; set; }
        public string? GstRegNo { get; set; }

        public Supplier() { }

        public Supplier(string Id, string Name, string ContactPersonName, int PhoneNo, int? FaxNo, string Address, string? GstRegNo, string Email)
        {
            this.Id = Id;
            this.Name = Name;
            this.PhoneNo = PhoneNo;
            this.FaxNo = FaxNo;
            this.Address = Address;
            this.GstRegNo = GstRegNo;
            this.Email = Email;
        }

    }
}

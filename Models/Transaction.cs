﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Models
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProductId { get; set; }
        public long Date { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public int Balance { get; set; }
        public int UpdatedByEmpId { get; set; }
        public string RefCode { get; set; }
        public virtual Product Product { get; set; }
        public virtual Employee UpdatedByEmp { get; set; }
    }
}

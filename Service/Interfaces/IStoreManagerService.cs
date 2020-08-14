using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Service.Interfaces
{
    public interface IStoreManagerService
    {
        public bool updatetop3supplier(List<TenderQuotation> tqlist);

        public List<TenderQuotation> retrievesuppliers(string pdtid);
    }
}

using SSIS_BOOT.Models;
using System.Collections.Generic;


namespace SSIS_BOOT.Service.Interfaces
{
    public interface IStoreManagerService
    {
        public bool UpdateTop3Supplier(List<TenderQuotation> tqlist);
        public List<TenderQuotation> RetrieveSuppliers(string pdtid);
    }
}

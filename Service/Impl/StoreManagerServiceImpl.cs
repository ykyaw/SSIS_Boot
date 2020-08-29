using SSIS_BOOT.Models;
using SSIS_BOOT.Repo;
using SSIS_BOOT.Service.Interfaces;
using System.Collections.Generic;

/**
 * @author Choo Teck Kian, Pei Jia En, Jade Lim
 */
namespace SSIS_BOOT.Service.Impl
{
    public class StoreManagerServiceImpl : IStoreManagerService
    {
        private TenderQuotationRepo tqrepo;

        public StoreManagerServiceImpl(TenderQuotationRepo tqrepo)
        {
            this.tqrepo = tqrepo;
        }

        public bool UpdateTop3Supplier(List<TenderQuotation> tqlist)
        {
            int currentyear = System.DateTime.Now.Year;
            tqrepo.UpdateTop3Supplier(tqlist, currentyear);
            return true;
        }
        public List<TenderQuotation> RetrieveSuppliers(string pdtid)
        {
            List<TenderQuotation> tqlist = tqrepo.RetrieveSuppliers(pdtid);
            return tqlist;
        }

    }
}

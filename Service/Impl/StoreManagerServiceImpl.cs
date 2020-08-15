using SSIS_BOOT.Models;
using SSIS_BOOT.Repo;
using SSIS_BOOT.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Service.Impl
{
    public class StoreManagerServiceImpl:IStoreManagerService
    {
        private TenderQuotationRepo tqrepo;

        public StoreManagerServiceImpl(TenderQuotationRepo tqrepo)
        {
            this.tqrepo = tqrepo;
        }

        public bool updatetop3supplier(List<TenderQuotation> tqlist)
        {
            //testing
            //string prdtid = "P043";
            //tqlist = tqrepo.gettop3suppliers(prdtid);
            int currentyear = System.DateTime.Now.Year;
            tqrepo.updatetop3supplier(tqlist, currentyear);
            return true;
        }
        public List<TenderQuotation> retrievesuppliers(string pdtid)
        {
            List < TenderQuotation> tqlist= tqrepo.retrievesuppliers(pdtid);
            return tqlist;
        }

    }
}

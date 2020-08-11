using SSIS_BOOT.Models;
using SSIS_BOOT.Repo;
using SSIS_BOOT.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Service.Impl
{
    public class StoreClerkServiceImpl : IStoreClerkService
    {
        public ProductRepo prepo;
        public PurchaseRequestRepo purreqrepo;

        public StoreClerkServiceImpl(ProductRepo prepo,PurchaseRequestRepo purreqrepo)
        {
            this.prepo = prepo;
            this.purreqrepo = purreqrepo;
        }

        public List<Product> getallcat()
        {
            return prepo.findallcat();
        }

        public List<PurchaseRequestDetail> getpurchasereq()
        {
            return purreqrepo.findallpurchasereq();
        }
    }
}

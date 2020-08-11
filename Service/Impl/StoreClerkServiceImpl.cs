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
        public PurchaseOrderRepo porepo;
        public PurchaseOrderDetailRepo podrepo;
        public RequisitionRepo rrepo;

        public StoreClerkServiceImpl(ProductRepo prepo,PurchaseRequestRepo purreqrepo,PurchaseOrderRepo porepo, PurchaseOrderDetailRepo podrepo, RequisitionRepo rrepo)
        {
            this.prepo = prepo;
            this.purreqrepo = purreqrepo;
            this.porepo = porepo;
            this.podrepo = podrepo;
            this.rrepo = rrepo;
        }

        public List<Product> getallcat()
        {
            return prepo.findallcat();
        }

        public List<Requisition> getallreqform()
        {
            return rrepo.findallreqform();
        }

        public List<PurchaseOrderDetail> getpoddetails(int poId)
        {
            return podrepo.findpodetails(poId);
        }

        public List<PurchaseOrder> getpurchaseorders()
        {
            return porepo.findallpurchaseorder();
        }

        public List<PurchaseRequestDetail> getpurchasereq()
        {
            return purreqrepo.findallpurchasereq();
        }
    }
}

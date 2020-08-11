using Microsoft.AspNetCore.Http;
using SSIS_BOOT.Common;
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
        public RequisitionDetailRepo rdrepo;
        public TransactionRepo trepo;
        public RetrievalRepo retrivrepo;
        public TenderQuotationRepo tqrepo;

        public StoreClerkServiceImpl(ProductRepo prepo,PurchaseRequestRepo purreqrepo,PurchaseOrderRepo porepo, PurchaseOrderDetailRepo podrepo, 
            RequisitionRepo rrepo, RequisitionDetailRepo rdrepo, TransactionRepo trepo, TenderQuotationRepo tqrepo, RetrievalRepo retrivrepo)

        {
            this.prepo = prepo;
            this.purreqrepo = purreqrepo;
            this.porepo = porepo;
            this.podrepo = podrepo;
            this.rrepo = rrepo;
            this.rdrepo = rdrepo;
            this.trepo = trepo;
            this.retrivrepo = retrivrepo;
            this.tqrepo = tqrepo;
        }

        public List<Product> getallcat()
        {
            return prepo.findallcat();
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
        public List<Requisition> getallreqform()
        {
            return rrepo.findallreqform();
        }
        public List<Requisition> getReqformByDeptId(string deptID)
        {
            return rrepo.findreqformByDeptID(deptID);
        }

        public List<Transaction> retrievestockcard(string productId)
        {
            return trepo.retrievestockcard(productId);
        }


        public Retrieval genretrievalform(long date, int clerkid)
        {
            Retrieval r1 = new Retrieval();
            r1.ClerkId = clerkid;
            r1.DisbursedDate = date;
            r1.Status = Status.RetrievalStatus.created;
            Retrieval r2 = retrivrepo.genretrievalandreturn(r1, clerkid); //checks if retrieval form already exists based on date. if no, creates a new retrieval form and returns the newly created form. if yes, return previously created form  

            List<RequisitionDetail> rd = new List<RequisitionDetail>();
            List<Requisition> req1 = rrepo.findrequsitionbycollectiondate(date);
            foreach (Requisition r in req1)
            {
                foreach (RequisitionDetail detail in r.RequisitionDetails)
                {
                    detail.RetrievalId = r2.Id; //assign the retrieval Id to each requsitiondetail 
                    RequisitionDetail x = rdrepo.updateretrievalid(detail); //and update the requisition details, then return it back
                    rd.Add(x);
                }
            }
            r2.RequisitionDetails = rd.GroupBy(m => m.Product.Description).SelectMany(r => r).ToList();
            return r2;
        }

        public List<TenderQuotation> gettop3suppliers(string productId)
        {
            return tqrepo.gettop3suppliers(productId);
        }
    }
}

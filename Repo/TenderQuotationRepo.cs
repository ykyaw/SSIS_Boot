using Microsoft.EntityFrameworkCore;
using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SSIS_BOOT.Repo
{
    public class TenderQuotationRepo
    {
        private SSISContext dbcontext;
        public TenderQuotationRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public List<TenderQuotation> GetTop3Suppliers(string pdtId)
        {
            //to insert the current timestamp and extract the year           
            DateTime now = DateTime.Today;
            int year = now.Year;

            IEnumerable<TenderQuotation> tqlist = (from tq in dbcontext.TenderQuotations
                                              where tq.ProductId == pdtId && tq.Year == year && tq.Rank !=null
                                              orderby tq.Rank ascending
                                              select tq).Include(m => m.Product).Include(m => m.Supplier).Take(3);

            List<TenderQuotation> tqlist2 = tqlist.ToList();
            return tqlist2;
        }

        public bool UpdateTop3Supplier(List<TenderQuotation> tqlist, int currentyear)
        {
            string productIdtoUpdate = tqlist[0].ProductId;
            List<TenderQuotation> originTQList = dbcontext.TenderQuotations.Where(m => m.ProductId == productIdtoUpdate && m.Year == currentyear).ToList();
            foreach(TenderQuotation k in originTQList)
            {
                k.Rank = null;
            }
            foreach(TenderQuotation i in tqlist)
            {
                foreach(TenderQuotation j in originTQList)
                {
                    if(i.SupplierId == j.SupplierId)
                    {
                        j.Rank = i.Rank;
                    }
                }
            }
            dbcontext.SaveChanges();
            return true;
        }

        public List<TenderQuotation> RetrieveSuppliers(string pdtid)
        {
            List<TenderQuotation> tqlist = dbcontext.TenderQuotations.Include(m=>m.Product).Include(m => m.Supplier).Where(m => m.ProductId == pdtid).ToList();
            return tqlist;
        }

        public TenderQuotation GetFirstTenderbyProdutId(string ProductId)
        {

            DateTime now = DateTime.Today;
            int year = now.Year;
            try
            {
                TenderQuotation firsttq = (from tq in dbcontext.TenderQuotations
                                           where tq.ProductId == ProductId && tq.Year == year && tq.Rank != null
                                           orderby tq.Rank ascending
                                           select tq).Include(m => m.Product).Include(m => m.Supplier).Take(1).FirstOrDefault();
                if (firsttq == null)
                {
                    throw new Exception();
                }
                return firsttq;
            }
            catch
            {
                throw new Exception("Error finding tender quotation by this product id");
            }
        }
    }
}

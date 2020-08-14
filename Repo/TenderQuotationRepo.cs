using Microsoft.EntityFrameworkCore;
using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Repo
{
    public class TenderQuotationRepo
    {
        private SSISContext dbcontext;
        public TenderQuotationRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public List<TenderQuotation> gettop3suppliers(string pdtId)
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
        public bool updatetop3supplier(List<TenderQuotation> tqlist)
        {
            foreach(TenderQuotation tq in tqlist)
            {
                var original = dbcontext.TenderQuotations.Find(tq.Id);
                if (original == null)
                {
                    throw new Exception();
                }
                //if (tq.SupplierId == "CHEP")
                //{
                //    tq.Rank = 2;

                //}
                dbcontext.Entry(original).CurrentValues.SetValues(tq);
                dbcontext.SaveChanges();
            }
            return true;
        }

        public List<TenderQuotation> retrievesuppliers(string pdtid)
        {
            List<TenderQuotation> tqlist = dbcontext.TenderQuotations.Include(m => m.Supplier).Where(m => m.ProductId == pdtid).ToList();
            return tqlist;
        }
    }
}

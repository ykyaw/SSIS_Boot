﻿using Microsoft.EntityFrameworkCore;
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
    }
}

﻿using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Repo
{
    public class TransactionRepo
    {
        private SSISContext dbcontext;
        public TransactionRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public List<Transaction> retrievestockcard(string productId)
        {
            List<Transaction> lr = dbcontext.Transactions.Where(m => m.ProductId == productId).ToList();
            return lr;
        }
    }
}
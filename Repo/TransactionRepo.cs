using Microsoft.EntityFrameworkCore;
using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System.Collections.Generic;
using System.Linq;


namespace SSIS_BOOT.Repo
{
    public class TransactionRepo
    {
        private SSISContext dbcontext;
        public TransactionRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public List<Transaction> RetrieveStockcard(string productId)
        {
            List<Transaction> lr = dbcontext.Transactions.Include(m=>m.Product).Include(m=>m.UpdatedByEmp).Where(m => m.ProductId == productId).ToList();
            return lr;
        }
        public bool SaveNewTransaction(Transaction t1)
        {
            dbcontext.Transactions.Add(t1);
            dbcontext.SaveChanges();
            return true;            
        }

        public Transaction GetLatestTransactionByProductId(string productId)
        {
            Transaction t = dbcontext.Transactions.Include(m=>m.Product).ThenInclude(m=>m.Category).Where(m => m.ProductId == productId).OrderByDescending(m => m.Date).ThenByDescending(m=>m.Id).FirstOrDefault();
            return t;
        }
    }
}

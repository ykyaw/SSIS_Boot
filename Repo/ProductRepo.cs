using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils;
using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Repo
{
    public class ProductRepo
    {
        private SSISContext dbcontext;

        public ProductRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public List<Product> FindAllCat()
        {
            List<Product> plist = dbcontext.Products.Include(m=>m.Category).ToList();
            return plist;
        }

        public Product FindProductById(string pdtid)
        {
            return dbcontext.Products.Find(pdtid);
        }

    }
}

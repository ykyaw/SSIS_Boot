using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System.Linq;


namespace SSIS_BOOT.Repo
{
    public class SupplierRepo
    {
        private SSISContext dbcontext;
        public SupplierRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public Supplier FindSupplierById(string supplierid)
        {
            return dbcontext.Suppliers.Where(item => item.Id == supplierid).FirstOrDefault();
        }

    }
}

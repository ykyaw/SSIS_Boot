using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System.Collections.Generic;
using System.Linq;


namespace SSIS_BOOT.Repo
{
    public class CollectionPointRepo
    {

        private SSISContext dbcontext;

        public CollectionPointRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public List<CollectionPoint> GetAllCollectionPoint()
        {
            List<CollectionPoint> clist = dbcontext.CollectionPoints.ToList();
            return clist;
        }

        public CollectionPoint GetStoreCollectionPoint()
        {
            CollectionPoint storecp=dbcontext.CollectionPoints.Where(m => m.Id == 6).FirstOrDefault();
            return storecp;
        }

        public CollectionPoint GetDeptCollectionPoint(Department dp)
        {
            CollectionPoint cp = dbcontext.CollectionPoints.Where(m => m.Id == dp.CollectionPointId).FirstOrDefault();
            return cp;
        }
    }
}

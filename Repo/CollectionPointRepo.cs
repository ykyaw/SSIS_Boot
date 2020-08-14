using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


    }
}

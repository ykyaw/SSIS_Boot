using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Repo
{
    public class RequisitionDetailRepo
    {
        private SSISContext dbcontext;
        public RequisitionDetailRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public List<RequisitionDetail> getrequisitiondetail(int reqid)
        {
            List<RequisitionDetail> rd = dbcontext.RequisitionDetails.Where(m => m.RequisitionId == reqid).ToList();
            return rd;
        }

    }
}

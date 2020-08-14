using Microsoft.EntityFrameworkCore;
using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Repo
{
    public class DepartmentRepo
    {
        private SSISContext dbcontext;
        public DepartmentRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public List<Department> findalldepartment() 
        {
            List<Department> dlist = dbcontext.Departments.ToList();
            return dlist;
        }

        public Department findDepartmentById(string deptId)
        {
            return dbcontext.Departments.Include(m => m.CollectionPoint).Where(m => m.Id == deptId).FirstOrDefault();
        }

        public bool UpdateCollectionPoint(string deptid, int collectionpointId)
        {
            try
            {
                var original = dbcontext.Departments.Find(deptid);
                if (original == null)
                {
                    throw new Exception();
                }
                original.CollectionPointId = collectionpointId;
                dbcontext.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Error updating collection point");
            }


        }

    }
}

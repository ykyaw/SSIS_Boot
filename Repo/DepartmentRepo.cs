using Microsoft.EntityFrameworkCore;
using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SSIS_BOOT.Repo
{
    public class DepartmentRepo
    {
        private SSISContext dbcontext;
        public DepartmentRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public List<Department> FindAllDepartment() 
        {
            List<Department> dlist = dbcontext.Departments.ToList();
            return dlist;
        }

        public Department FindDepartmentById(string deptId)
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

        public bool AssignDeptRep(int empid, string deptid)
        {
            try
            {
                Department dept = dbcontext.Departments.Where(m => m.Id == deptid).FirstOrDefault();
                if (dept != null)
                {
                    dept.RepId = empid;
                }
                dbcontext.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Error assigning department representative. Please try again");
            }
        }

        public Department FindDeptbyRepID(int empid)
        {
            Department dp = dbcontext.Departments.Where(m => m.RepId == empid).FirstOrDefault();
            return dp;
        }
    }
}

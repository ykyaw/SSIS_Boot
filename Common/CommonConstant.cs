using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Common
{
    public static class CommonConstant
    {
        public static class ErrorCode
        {
            public static readonly int INVALID_TOKEN=510;
            public static readonly int NO_PERMISSIN = 511;
        }

        public static class ROLE
        {
            public static readonly string STORE_CLERK = "sc";
            public static readonly string STORE_SUPERVISOR = "ss";
            public static readonly string STORE_MANAGER = "sm";
            public static readonly string DEPARTMENT_HEAD = "dh";
            public static readonly string DEPARTMENT_EMPLOYEE = "de";
            public static readonly string DEPARTMENT_REPRESENTATIVE = "dr";
            public static readonly string DEPARTMENT_DELEGATE = "dd";
        }

        public static Dictionary<string, string> Authorization = new Dictionary<string, string>()
        {
            { ROLE.STORE_CLERK,"Storeclerk" },
            {ROLE.STORE_MANAGER,"Storemgmt" },
            {ROLE.STORE_SUPERVISOR,"Storesup" },
            {ROLE.DEPARTMENT_EMPLOYEE,"Deptemp" },
            {ROLE.DEPARTMENT_HEAD,"Depthead" }
        };
    }
}

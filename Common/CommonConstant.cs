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

        public static Dictionary<string, List<string>> Authorization = new Dictionary<string, List<string>>()
        {
            { ROLE.STORE_CLERK,new List<string>(){ "Storeclerk"} },
            {ROLE.STORE_MANAGER,new List<string>(){ "Storemgmt", "Storeclerk" } },
            {ROLE.STORE_SUPERVISOR,new List<string>(){"Storesup","Storesup" } },
            {ROLE.DEPARTMENT_EMPLOYEE,new List<string>(){"Deptemp" } },
            {ROLE.DEPARTMENT_HEAD,new List<string>(){"Depthead", "Deptemp" } }
        };
    }
}

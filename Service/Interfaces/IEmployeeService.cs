using SSIS_BOOT.Models;


namespace SSIS_BOOT.Service.Interfaces
{
    public interface IEmployeeService
    {
        public Employee Login(Employee user);
        public Employee FindUserByEmail(string email);
    }
}

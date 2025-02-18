using EmpApp.DataAccess.Entities;
using EmpApp.Models;

namespace EmpApp.BL.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployee();
        Task<Employee?> GetEmployeeById(int id);
        Task<bool> AddEmployee(Emp employee);
        Task<bool> UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
}

using EmpApp.DataAccess.Entities;
using EmpApp.Models;

namespace EmpApp.DataAccess.Interfaces
{
    public interface IEmployeeRepo
    {
        Task<IEnumerable<Employee>> GetAllEmployee();
        Task<Employee?> GetEmployeeById(int id);
        Task<bool> AddEmployee(Emp employee);
        Task<bool> UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
}

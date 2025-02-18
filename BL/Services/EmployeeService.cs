using EmpApp.BL.Interfaces;
using EmpApp.DataAccess.Entities;
using EmpApp.DataAccess.Interfaces;
using EmpApp.Models;

namespace EmpApp.BL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return _employeeRepo.GetAllEmployee();
        }

        public Task<Employee?> GetEmployeeById(int id)
        {
            return _employeeRepo.GetEmployeeById(id);
        }
        //test
        public async Task<bool> AddEmployee(Emp employee)
        {
           return await _employeeRepo.AddEmployee(employee);
        }
        public async Task<bool> UpdateEmployee(Employee employee)
        {
            return await _employeeRepo.UpdateEmployee(employee);
        }

        public Task DeleteEmployee(int id)
        {
            return _employeeRepo.DeleteEmployee(id);
        }



    }
}

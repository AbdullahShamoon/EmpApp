using EmpApp.DataAccess.Entities;
using EmpApp.DataAccess.Interfaces;
using EmpApp.Models;
using Microsoft.EntityFrameworkCore;
using static EmpApp.DataAccess.Repositories.EmployeeRepo;

namespace EmpApp.DataAccess.Repositories
{

        public class EmployeeRepo : IEmployeeRepo
        {
            private readonly NgIpfDBContext _context;

            public EmployeeRepo(NgIpfDBContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Employee>> GetAllEmployee()
            {
            return await _context.Employees.ToListAsync();
            }

            public async Task<Employee?> GetEmployeeById(int id)
            {
                return await _context.Employees.FindAsync(id);
            }

            public async Task<bool> AddEmployee(Emp employee)
            {

            var obj = new Employee
            {
                Emp_Id = employee.Emp_Id,
                Emp_Name = employee.Emp_Name,
                Emp_Phone =Convert.ToInt32 (employee.Emp_Phone),
                Emp_Address = employee.Emp_Address

            };


            _context.Employees.Add(obj);

                await _context.SaveChangesAsync();
            return true;
            }

            public async Task<bool> UpdateEmployee(Employee employee)
            {
                    //Employee= new Employee


                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
            return true;
            }

            public async Task DeleteEmployee(int id)
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();
                }
            }

        }
  
}

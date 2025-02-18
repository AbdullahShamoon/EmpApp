using EmpApp.BL.Interfaces;
using EmpApp.DataAccess.Entities;
using EmpApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmpApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }



        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            var emps = await _employeeService.GetAllEmployee();
            return Ok(emps);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var emps = await _employeeService.GetEmployeeById(id);
            if (emps == null) return NotFound();
            return Ok(emps);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Employee>> Add([FromBody] Emp employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            // var data = await _employeeService.AddEmployee(employee);
            var data = await _employeeService.AddEmployee(employee);
            return Ok(data);
            //var createdEmployee = await _employeeService.AddEmployee(employee);
            //return CreatedAtAction(nameof(GetById), new { id = createdEmployee.Id }, createdEmployee);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Employee employee)
        {
            if (id != employee.Emp_Id)
            {
                return BadRequest();
            }
            var updatedEmployee = await _employeeService.UpdateEmployee(employee);
            return Ok(updatedEmployee);
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = _employeeService.DeleteEmployee(id);
            if (data ==  null) return NotFound();
            return NoContent();
        }
    }
}

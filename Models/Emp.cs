using System.ComponentModel.DataAnnotations;

namespace EmpApp.Models
{
    public class Emp
    {
        public required int Emp_Id { get; set; }
        public string Emp_Name { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be exactly 10 digits.")]
        public string? Emp_Phone { get; set; }
        public string? Emp_Address { get; set; }

    }
}

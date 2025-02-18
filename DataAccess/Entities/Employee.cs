using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmpApp.DataAccess.Entities;

[Table("Employee")]
public partial class Employee
{
    [Key]
    [Column("Emp_Id")]
    public int Emp_Id { get; set; }

    [Column("Emp_Name")]
    [StringLength(50)]
    public string Emp_Name { get; set; } = null!;

    [Column("Emp_Phone")]
    public int? Emp_Phone { get; set; }

    [Column("Emp_Address", TypeName = "character varying")]
    public string? Emp_Address { get; set; }
}

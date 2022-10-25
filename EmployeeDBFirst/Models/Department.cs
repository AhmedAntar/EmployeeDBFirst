using System;
using System.Collections.Generic;

namespace EmployeeDBFirst.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public string DepartmentAbbr { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}

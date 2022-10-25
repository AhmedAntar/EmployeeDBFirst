using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDBFirst.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }
    [Display(Name = "الاسم بالعربية")]
    public string? EmployeeNameArabic { get; set; }
    [Display(Name = "English Name")]
    public string EmployeeNameEnglish { get; set; } = null!;
    [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
    [Display(Name="Birthdate")]
    public DateTime Dbo { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
    public DateTime HiringDate { get; set; }
    public decimal Salary { get; set; }

    public int? CityId { get; set; }

    public int? DepartmentId { get; set; }

    public virtual City? City { get; set; }

    public virtual Department? Department { get; set; }
}

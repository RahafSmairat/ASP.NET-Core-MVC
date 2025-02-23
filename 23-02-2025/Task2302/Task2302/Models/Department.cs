using System;
using System.Collections.Generic;

namespace Task2302.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public string? Location { get; set; }

    public string? ManagerName { get; set; }

    public int? EmployeeCount { get; set; }
}

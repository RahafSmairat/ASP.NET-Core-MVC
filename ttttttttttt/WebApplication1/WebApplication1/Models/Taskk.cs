using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Taskk
{
    public int Id { get; set; }

    public string TaskName { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}

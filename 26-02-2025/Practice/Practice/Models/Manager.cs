﻿using System;
using System.Collections.Generic;

namespace Practice.Models;

public partial class Manager
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}

using System;
using System.Collections.Generic;

namespace Task2402.Models;

public partial class Userr
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;
}

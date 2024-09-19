using System;
using System.Collections.Generic;

namespace ElearningDB.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsBlocked { get; set; }

    public string Role { get; set; } = null!;
}

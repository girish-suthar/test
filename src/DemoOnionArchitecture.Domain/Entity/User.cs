using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoOnionArchitecture.Domain.Entity;

[Table("User")]
public partial class User
{
    [Key]
    public int UserId { get; set; }

    [StringLength(20)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string UserName { get; set; } = null!;

    [StringLength(50)]
    public string PasswordHash { get; set; } = null!;

    [StringLength(20)]
    public string Role { get; set; } = null!;
}

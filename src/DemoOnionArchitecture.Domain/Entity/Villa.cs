using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoOnionArchitecture.Domain.Entity;

public partial class Villa
{
    [Key]
    public int VillaId { get; set; }

    public bool IsOccupied { get; set; }

    public string VillaAddress { get; set; } = null!;

    public string VillaName { get; set; } = null!;
}

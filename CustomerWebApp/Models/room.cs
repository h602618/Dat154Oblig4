using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebApp.Models;

public partial class room
{
    [Key] public int nr { get; set; }
    public int quality { get; set; }

    public double size { get; set; }
    public int beds { get; set; }

    [InverseProperty("roomNrNavigation")]
    public virtual ICollection<requests> requests { get; set; } = new List<requests>();

    [InverseProperty("roomNrNavigation")]
    public virtual ICollection<reservations> reservations { get; set; } = new List<reservations>();
}

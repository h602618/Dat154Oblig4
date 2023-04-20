using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebApp.Models;

public partial class customer
{
    [Key]
    public int id { get; set; }

    public string name { get; set; } = null!;

    public string password { get; set; } = null!;

    [InverseProperty("customer")]
    public virtual ICollection<reservations> reservations { get; set; } = new List<reservations>();
}

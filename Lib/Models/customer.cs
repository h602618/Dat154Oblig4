﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Models;

public class customer
{
    [Key] public int id { get; set; }

    public string name { get; set; } = null!;

    public string password { get; set; } = null!;

    [InverseProperty("customer")]
    public virtual ICollection<reservations> reservations { get; set; } = new List<reservations>();
}

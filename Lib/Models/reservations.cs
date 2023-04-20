using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lib.Models;

public enum ReservationStatus
{
    Booked,
    CheckedIn
}
[PrimaryKey("customerId", "roomNr")]
public partial class reservations
{
    [Key] public int customerId { get; set; }

    [Key] public int roomNr { get; set; }

    [Column(TypeName = "timestamp(3) without time zone")]
    public DateTime start { get; set; }

    [Column(TypeName = "timestamp(3) without time zone")]
    public DateTime end { get; set; }

    public string status { get; set; } = ReservationStatus.Booked.ToString();

    [ForeignKey("customerId")]
    [InverseProperty("reservations")]
    public virtual customer customer { get; set; } = null!;

    [ForeignKey("roomNr")]
    [InverseProperty("reservations")]
    public virtual room roomNrNavigation { get; set; } = null!;
}

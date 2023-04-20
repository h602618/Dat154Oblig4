using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Models;

public enum RequestType
{
    Maintainer,
    Cleaner,
    Service
}
public enum RequestStatus
{
    New,
    InProgress,
    Finished
}
public partial class requests
{
    [Key] public int id { get; set; }

    public string? note { get; set; }

    public int roomNr { get; set; }

    public string type { get; set; } = null!;

    public string status { get; set; } = RequestStatus.New.ToString();

    [ForeignKey("roomNr")]
    [InverseProperty("requests")]
    public virtual room roomNrNavigation { get; set; } = null!;
}

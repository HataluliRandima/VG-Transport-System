using System;
using System.Collections.Generic;

namespace VG_TransportAPI.Models;

public partial class Feedback
{
    public int FId { get; set; }

    public string? FMessageC { get; set; }

    public string? FMessageD { get; set; }

    public string? FRateC { get; set; }

    public string? FRateD { get; set; }

    public int? OId { get; set; }

    public int? CId { get; set; }

    public int? DId { get; set; }

    public virtual Customer? CIdNavigation { get; set; }

    public virtual Driver? DIdNavigation { get; set; }

    public virtual Order? OIdNavigation { get; set; }
}

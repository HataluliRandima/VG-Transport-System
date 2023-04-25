using System;
using System.Collections.Generic;

namespace VG_TransportAPI.Models;

public partial class Payment
{
    public int PId { get; set; }

    public string? PType { get; set; }

    public string? PStatus { get; set; }

    public string? PAmount { get; set; }

    public int OId { get; set; }

    public int? CId { get; set; }

    public string? PTotamount { get; set; }

    public string? PPaydrive { get; set; }

    public virtual Customer? CIdNavigation { get; set; }

    public virtual Order OIdNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace VG_TransportAPI.Models;

public partial class Booking
{
    public int BId { get; set; }

    public int CId { get; set; }

    public DateTime? BDate { get; set; }

    public TimeSpan? BTime { get; set; }

    public string? BStatus { get; set; }

    public string? BUrlcode { get; set; }

    public string? BAmountesti { get; set; }

    public string? BAmountelocal { get; set; }

    public string? BNameproduct { get; set; }

    public string? BProddesc { get; set; }

    public string? BInitam { get; set; }

    public string? BCartype { get; set; }

    public string? BLf1 { get; set; }

    public string? BLf2 { get; set; }

    public string? BLf3 { get; set; }

    public string? BLf4 { get; set; }

    public string? BLd1 { get; set; }

    public string? BLd2 { get; set; }

    public string? BLd3 { get; set; }

    public string? BLd4 { get; set; }

    public string? BUrl { get; set; }

    public virtual Customer CIdNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

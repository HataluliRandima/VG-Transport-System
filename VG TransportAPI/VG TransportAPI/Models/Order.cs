using System;
using System.Collections.Generic;

namespace VG_TransportAPI.Models;

public partial class Order
{
    public int OId { get; set; }

    public string? OAmtesti { get; set; }

    public string? ODetailSen1 { get; set; }

    public string? ODetailSen2 { get; set; }

    public string? ODetailSen3 { get; set; }

    public string? OStatus { get; set; }

    public string? OUrlcode { get; set; }

    public int BId { get; set; }

    public int? DId { get; set; }

    public string? ODetailRec1 { get; set; }

    public string? ODetailRec2 { get; set; }

    public string? ODetailRec3 { get; set; }

    public string? OStatus1 { get; set; }

    public string? ODesc { get; set; }

    public string? OPaydriver { get; set; }

    public int? CId { get; set; }

    public virtual Booking BIdNavigation { get; set; } = null!;

    public virtual Customer? CIdNavigation { get; set; }

    public virtual Driver? DIdNavigation { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}

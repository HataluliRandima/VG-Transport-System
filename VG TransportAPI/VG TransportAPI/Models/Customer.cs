using System;
using System.Collections.Generic;

namespace VG_TransportAPI.Models;

public partial class Customer
{
    public int CId { get; set; }

    public string CName { get; set; } = null!;

    public string CSurname { get; set; } = null!;

    public string CEmail { get; set; } = null!;

    public string CPassword { get; set; } = null!;

    public string CNumber { get; set; } = null!;

    public string? CStatus { get; set; }

    public string? CBlocked { get; set; }

    public string? CAdd1 { get; set; }

    public string? CAdd2 { get; set; }

    public string? CAdd3 { get; set; }

    public string? CAdd4 { get; set; }

    public string? CUrl { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}

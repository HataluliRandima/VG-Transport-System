using System;
using System.Collections.Generic;

namespace VG_TransportAPI.Models;

public partial class Driver
{
    public int DId { get; set; }

    public string DName { get; set; } = null!;

    public string DSurname { get; set; } = null!;

    public string DEmail { get; set; } = null!;

    public string DPhone { get; set; } = null!;

    public string DPassword { get; set; } = null!;

    public string? DAdd1 { get; set; }

    public string? DAdd2 { get; set; }

    public string? DAdd3 { get; set; }

    public string? DAdd4 { get; set; }

    public string? DStatus { get; set; }

    public string? DBlocked { get; set; }

    public string? DUrl { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

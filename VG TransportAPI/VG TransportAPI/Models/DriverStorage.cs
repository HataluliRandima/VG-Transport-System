using System;
using System.Collections.Generic;

namespace VG_TransportAPI.Models;

public partial class DriverStorage
{
    public int DsId { get; set; }

    public string DsName { get; set; } = null!;

    public string DsSurname { get; set; } = null!;

    public string DsEmail { get; set; } = null!;

    public string DsNumber { get; set; } = null!;

    public string? DsStatus { get; set; }

    public string? DsStatusAct { get; set; }

    public string? DsDoc1 { get; set; }

    public string? DsDoc2 { get; set; }

    public string? DsDoc3 { get; set; }
}

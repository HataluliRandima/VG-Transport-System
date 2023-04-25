using System;
using System.Collections.Generic;

namespace VG_TransportAPI.Models;

public partial class Car
{
    public int CrId { get; set; }

    public string CrName { get; set; } = null!;

    public string? CrModel { get; set; }

    public string? CrType { get; set; }

    public string? CrRegPlate { get; set; }

    public string? CrPaper1 { get; set; }

    public string? CrPaper2 { get; set; }

    public string? CrDescription { get; set; }

    public int DId { get; set; }

    public virtual Driver DIdNavigation { get; set; } = null!;
}

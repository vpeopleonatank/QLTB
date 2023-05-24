using System;
using System.Collections.Generic;

namespace QLTB.Test_models;

public partial class Thietbi
{
    public int Matb { get; set; }

    public int Madv { get; set; }

    public int Maloai { get; set; }

    public string? Tentb { get; set; }

    public string? Nuocsx { get; set; }

    public virtual Donvi MadvNavigation { get; set; } = null!;

    public virtual Loaithietbi MaloaiNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace QLTB.Test_models;

public partial class Donvi
{
    public int Madv { get; set; }

    public string? Tendv { get; set; }

    public virtual ICollection<Thietbi> Thietbis { get; set; } = new List<Thietbi>();
}

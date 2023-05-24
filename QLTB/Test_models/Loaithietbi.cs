using System;
using System.Collections.Generic;

namespace QLTB.Test_models;

public partial class Loaithietbi
{
    public int Maloai { get; set; }

    public string? Tenloai { get; set; }

    public string? Danhmuc { get; set; }

    public string? Ghichu { get; set; }

    public virtual ICollection<Thietbi> Thietbis { get; set; } = new List<Thietbi>();
}

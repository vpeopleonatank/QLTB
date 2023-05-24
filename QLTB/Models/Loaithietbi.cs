using Microsoft.EntityFrameworkCore;

namespace QLTB.Models
{
    public class Loaithietbi
    {
        public int Maloai { get; set; }
        public string? Tenloai { get; set; }
        public string? Danhmuc { get; set; }
        public string? Ghichu { get; set; }
        public ICollection<Thietbi>? Thietbis { get; set; }
    }
}

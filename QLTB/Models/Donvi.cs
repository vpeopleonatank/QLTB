using Microsoft.EntityFrameworkCore;

namespace QLTB.Models
{
    public class Donvi
    {
        public int Madv { get; set; }
        public string? Tendv { get; set; }
        public ICollection<Thietbi>? Thietbis { get; set; }
    }
}

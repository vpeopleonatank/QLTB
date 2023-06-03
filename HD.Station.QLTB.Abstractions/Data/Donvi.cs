using Microsoft.EntityFrameworkCore;

namespace HD.Station.Qltb.Abstractions.Data
{
    public class Donvi
    {

        public int Madv { get; set; }
        public string? Tendv { get; set; }
        public ICollection<Thietbi>? Thietbis { get; set; }
    }
}

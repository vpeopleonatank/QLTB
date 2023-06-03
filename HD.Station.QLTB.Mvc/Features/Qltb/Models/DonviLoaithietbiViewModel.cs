using HD.Station.Qltb.Abstractions.Data;

namespace HD.Station.Qltb.Mvc.Models
{
    public class DonviLoaithietbiViewModel
    {
        public ICollection<Donvi>? Donvis { get; set; }
        public ICollection<Loaithietbi>? Loaithietbis { get; set; }

    }
}

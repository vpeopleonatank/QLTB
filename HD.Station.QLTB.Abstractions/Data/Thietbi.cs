using System.ComponentModel.DataAnnotations;

namespace HD.Station.Qltb.Abstractions.Data
{
    public class Thietbi
    {
        public int Matb { get; set; }
        public int Madv { get; set; }
        public int Maloai { get; set; }
        [Display(Name = "Ten thiet bi")]
        public string? Tentb { get; set; }
        [Display(Name = "Nuoc san xuat")]
        public string? Nuocsx { get; set; }
        [Display(Name = "Don vi")]
        public Donvi? Donvi { get; set; }
        [Display(Name = "Loai thiet bi")]
        public Loaithietbi? Loaithietbi { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using HD.Station.Qltb.Abstractions.DTO;

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
        public Donvi Donvi { get; set; } = null!;
        [Display(Name = "Loai thiet bi")]
        public Loaithietbi Loaithietbi { get; set; } = null!;

        public void UpdateThietbi(UpdateDeviceDto updateDeviceDto)
        {
          Madv = updateDeviceDto.Madv;
          Maloai = updateDeviceDto.Maloai;
          Tentb = updateDeviceDto.Tentb;
          Nuocsx = updateDeviceDto.Nuocsx;
        }
    }
}

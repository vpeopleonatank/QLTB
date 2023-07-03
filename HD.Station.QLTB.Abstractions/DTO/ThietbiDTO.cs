using HD.Station.Qltb.Abstractions.Data;
using System.ComponentModel.DataAnnotations;

namespace HD.Station.Qltb.Abstractions.DTO
{
    public class ThietbiDTO
    {
        public int Matb { get; set; }
        public int Madv { get; set; }
        public int Maloai { get; set; }
        public string? Tentb { get; set; }
        public string? Nuocsx { get; set; }
        [Display(Name = "Don vi")]
        public string? Tendv { get; set; }
        [Display(Name = "Loai thiet bi")]
        public string? Tenloaitb { get; set; }

        public static ThietbiDTO MapFromThietbi(Thietbi thietbi)
        {
            return new ThietbiDTO
            {
                Madv = thietbi.Madv,
                Matb = thietbi.Matb,
                Maloai = thietbi.Maloai,
                Tentb = thietbi.Tentb,
                Nuocsx = thietbi.Nuocsx,
                Tendv = thietbi.Donvi.Tendv,
                Tenloaitb = thietbi.Loaithietbi.Tenloai,
            };
        }
    }
    public class PagingParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }

    public record DevicesResponseDto(List<ThietbiDTO> devices, int DevicesCount);
    public record AddDevicesResponseDto(List<Donvi> donvis,
        List<Loaithietbi> loaithietbis, ThietbiDTO thietbiDto);
    public record NewDeviceDto(int Madv, int Maloai, string Tentb, string Nuocsx);
    public record UpdateDeviceDto(int Madv, int Maloai, 
        string Tentb, string Nuocsx);
}

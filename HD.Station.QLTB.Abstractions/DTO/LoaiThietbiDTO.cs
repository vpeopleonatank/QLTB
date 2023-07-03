using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.Station.Qltb.Abstractions.DTO
{
    public class LoaiThietbiDTO
    {
        public int Maloai { get; set; }
        public string? Tenloai { get; set; }
        public string? Danhmuc { get; set; }
        public string? Ghichu { get; set; }
    }
    public record LoaithietbisResponseDto(List<LoaiThietbiDTO> LoaiThietbiDTOs);
}

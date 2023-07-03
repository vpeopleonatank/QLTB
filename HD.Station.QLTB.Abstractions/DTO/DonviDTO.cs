using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.Station.Qltb.Abstractions.DTO
{
    public class DonviDTO
    {
        public int Madv { get; set; }
        public string? Tendv { get; set; }
    }
    public record DonvisResponseDto(List<DonviDTO> DonviDTOs);
}

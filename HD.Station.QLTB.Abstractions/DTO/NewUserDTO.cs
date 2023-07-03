using System.ComponentModel.DataAnnotations;

namespace HD.Station.Qltb.Abstractions.DTO
{
    public class NewUserDTO
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? Username { get; set; }
    }
}

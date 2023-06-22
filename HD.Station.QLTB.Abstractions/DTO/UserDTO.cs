using HD.Station.Qltb.Abstractions.Data;
using HD.Station.Qltb.Abstractions.Abstractions;

namespace HD.Station.Qltb.Abstractions.DTO
{
    public class UserDTO
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Bio { get; set; }
        public string? Image { get; set; }
        public string? Token { get; set; }
    }

    public static class UserMapper
    {
        public static UserDTO Map(this UserAccount user, IJwtTokenGenerator jwtTokenGenerator)
        {
            return new()
            {
                Email = user.Email,
                Token = jwtTokenGenerator.CreateToken(user),
                Username = user.Name,
                Bio = user.Bio!,
                Image = user.Image!,
            };
        }
    }
}

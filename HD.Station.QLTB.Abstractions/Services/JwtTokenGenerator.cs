using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using HD.Station.Qltb.Abstractions.Abstractions;
using HD.Station.Qltb.Abstractions.Data;
using HD.Station.Qltb.Abstractions.Options;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HD.Station.Qltb.Abstractions.Services;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtOptions _jwtOptions;

    public JwtTokenGenerator(IOptionsMonitor<JwtOptions> options)
    {
        _jwtOptions = options.CurrentValue;
    }

    public string CreateToken(UserAccount user)
    {
        if (_jwtOptions.SecretKey is null)
        {
            throw new ArgumentException("You must set a JWT secret key");
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _jwtOptions.Issuer,
            Audience = _jwtOptions.Audience,
            Subject = new ClaimsIdentity(new Claim[] {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString(CultureInfo.InvariantCulture)),
                new(JwtRegisteredClaimNames.Name, user.Name),
                new(JwtRegisteredClaimNames.Email, user.Email)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var response = tokenHandler.WriteToken(token);

        return response;
    }
}

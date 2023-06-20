using HD.Station.Qltb.Abstractions.Data;

namespace HD.Station.Qltb.Abstractions.Abstractions;

public interface IJwtTokenGenerator
{
    string CreateToken(User user);
}

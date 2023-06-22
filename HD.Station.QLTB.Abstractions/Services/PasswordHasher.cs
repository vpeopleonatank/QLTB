﻿using HD.Station.Qltb.Abstractions.Abstractions;

namespace HD.Station.Qltb.Abstractions.Services;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Check(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }

}

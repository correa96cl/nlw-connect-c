using System;

namespace Connect.Api.Infrastructure.Security.Cryptography;

public class BCryptAlogrithm
{
    public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
}

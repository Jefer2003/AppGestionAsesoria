using System;
using System.Security.Claims;
using CleanArchitecture.Domain.Enums;
using Microsoft.AspNetCore.Authentication;

namespace CleanArchitecture.IntegrationTests.Infrastructure.Auth;

public sealed class TestAuthenticationOptions : AuthenticationSchemeOptions
{
    public static Guid TestUserId = new("561e4300-94d6-4c3f-adf5-31c1bdbc64df");
    public const string Email = "integration@tests.com";
    public const string FirstName = "Integration";
    public const string LastName = "Tests";

    public ClaimsIdentity Identity { get; } = new ClaimsIdentity(
        new[]
        {
            new Claim(ClaimTypes.Email, Email),
            new Claim(ClaimTypes.Role, UserRole.Admin.ToString()),
            new Claim(ClaimTypes.NameIdentifier, TestUserId.ToString()),
            new Claim(ClaimTypes.Name, $"{FirstName} {LastName}")
        },
        "test");
}
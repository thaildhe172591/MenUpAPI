using System;
using System.Collections.Generic;

namespace SkinShopAPI.Models;

public partial class EmailVerification
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string? Username { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string? FullName { get; set; }

    public string? OtpCode { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ExpiredAt { get; set; }

    public string? Gender { get; set; }

    public DateOnly? DateOfBirth { get; set; }
}

﻿namespace eCommerce.Core.DTO;
public record AuthenticationResponse(
    Guid UserID,
    string? Email,
    string? PersonName,
    string? Gender,
    string? Token,
    bool Success)
{
    // Parameterless constructor for AutoMapper
    public AuthenticationResponse()
        : this(default, default, default, default, default, default)
    {
    }
}
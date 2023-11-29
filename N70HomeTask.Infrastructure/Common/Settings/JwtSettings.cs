﻿namespace N70HomeTask.Infrastructure.Common.Settings;

public class JwtSettings
{
    public string SecretKey { get; set; }
    public bool ValidateAudience { get; set; }
    public string ValidAudience { get; set; }
    public bool ValidateIssuer { get; set; }
    public string ValidIssuer { get; set; }
    public bool ValidateLifeTime { get; set; }
    public bool ValidateIssuerSigningKey { get; set; }
    public int ExpirationTimeInMinutes { get; set; }
}
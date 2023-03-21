namespace CommonServices.Auth;

public class JwtSettings
{
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public string? SecrectKey { get; set; }
}
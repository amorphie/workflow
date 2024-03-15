using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace amorphie.workflow.core.Token;
public class TokenOptions
{
    public string Issuer { get; init; } = default!;
    public string Secret { get; init; } = default!;
}
public class TokenFactory
{
    private readonly TokenOptions _tokenOptions;

    public TokenFactory(IOptions<TokenOptions> options)
    {
        _tokenOptions = options.Value;
    }

    public string CreateToken(string environmentName, string hash)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Locality,environmentName),
            new Claim(ClaimTypes.Hash,hash)
       };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _tokenOptions.Secret));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
                            issuer: _tokenOptions.Issuer,
                            claims: claims,
                            expires: DateTime.UtcNow.AddDays(1),
                            signingCredentials: cred);
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }


    public bool ValidateToken(
    string token,
    out JwtSecurityToken? jwt
    )
    {
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _tokenOptions.Secret));
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = _tokenOptions.Issuer,
            ValidateAudience = false,
            //ValidAudience = audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateLifetime = true,

        };

        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            jwt = (JwtSecurityToken)validatedToken;

            return true;
        }
        catch (SecurityTokenValidationException ex)
        {
            jwt = null;
            return false;
        }
    }
}
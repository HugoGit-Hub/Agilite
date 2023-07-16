using Agilite.UI.Services.Exceptions;
using Microsoft.Extensions.Caching.Memory;
using System.IdentityModel.Tokens.Jwt;

namespace Agilite.UI.Services.Services;

public static class TokenService
{
    private static readonly MemoryCache MemoryCache = new(new MemoryCacheOptions());

    public static void StoreTokenInCache(string token)
    {
        MemoryCache.Set("token", token, TimeSpan.FromHours(3));
    }

    public static string GetClaimValue(string claimType)
    {
        var jwtHandler = new JwtSecurityTokenHandler();
        var jwtToken = jwtHandler.ReadJwtToken(GetToken());
        var claim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == claimType);

        return claim is null ? throw new ClaimNullException() : claim.Value;
    }

    private static string? GetToken()
    {
        if (MemoryCache.TryGetValue("token", out string? cachedToken))
        {
            return cachedToken;
        }

        throw new NoTokenStoredInCacheException();
    }
}
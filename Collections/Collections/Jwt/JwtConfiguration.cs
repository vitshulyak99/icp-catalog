using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Collections.Jwt
{
    public class JwtConfiguration
    {
        private const string DefaultIssuer = "DefIssuer";
        private const string DefaultAudience = "DefIssuer";
        private const int DefaultLifeTimeMinutes = 555;
        
        protected JwtConfiguration(){}
        
        public TimeSpan LifeTime { get; set; }

        public string Key { get; init; }

        public string Audience { get; init; }

        public string Issuer { get; init; }

        public static JwtConfiguration Create(IConfiguration cfg) => new()
        {
            Issuer = cfg[nameof(Issuer)] ?? DefaultIssuer,
            Audience = cfg[nameof(Audience)] ?? DefaultAudience,
            Key = cfg[nameof(Key)] ?? Guid.NewGuid().ToString(),
            LifeTime = int.TryParse(cfg[nameof(LifeTime)], out var lifeTime)
                ? TimeSpan.FromMinutes(lifeTime)
                : TimeSpan.FromMinutes(DefaultLifeTimeMinutes)
        };

        public SecurityKey GetSecurityKey() => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
    }
}
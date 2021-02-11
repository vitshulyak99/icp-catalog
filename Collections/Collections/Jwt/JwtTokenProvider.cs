using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Collections.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Collections.Jwt
{
    public class JwtTokenProvider
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly JwtConfiguration _configuration;
        private readonly RoleManager<AppRole> _roleManager;
        
        public JwtTokenProvider(UserManager<AppUser> userManager, JwtConfiguration configuration, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        public async Task<string> GenerateToken(string login, string password)
        {
            var user = await _userManager.FindByEmailAsync(login);
                
            if (user is null || !await _userManager.CheckPasswordAsync(user,password)) return string.Empty;
            var claimsIdentity = await GetClaims(user);
            if (claimsIdentity is null) return null;
            var now = DateTime.Now;
            var token = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                claims: claimsIdentity.Claims,
                now,
                expires:now.Add(_configuration.LifeTime),
                signingCredentials: new SigningCredentials(_configuration.GetSecurityKey(),SecurityAlgorithms.HmacSha256Signature));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<ClaimsIdentity> GetClaims(AppUser user)
        {
            var claimsIdentity = new ClaimsIdentity();
            var claims = new List<Claim>();
            if (_userManager.SupportsUserClaim)
            {
               claims.AddRange(await _userManager.GetClaimsAsync(user));  
            }

            if (_userManager.SupportsUserRole)
            {
                var roles = await _userManager.GetRolesAsync(user);
                claims.AddRange(roles.Select(x=> new Claim(claimsIdentity.RoleClaimType,x)));
                if (_roleManager.SupportsRoleClaims)
                {
                   var roleClaims = _roleManager.Roles.Where(x => roles.Contains(x.Name)).ToList().SelectMany(x=> _roleManager.GetClaimsAsync(x).GetAwaiter().GetResult()).ToList();
                   claims.AddRange(roleClaims);
                }
            }
            
            claimsIdentity.AddClaims(claims);
            return claimsIdentity;
        }
    }
}
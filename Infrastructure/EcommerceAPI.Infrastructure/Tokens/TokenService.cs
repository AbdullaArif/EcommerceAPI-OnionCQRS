using EcommerceAPI.Application.Interfaces.Tokens;
using EcommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Infrastructure.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenSettings _tokenSettings;

        public TokenService(UserManager<User> userManager, IOptions<TokenSettings> optionsTokenSettings)
        {
            _userManager = userManager;
            _tokenSettings = optionsTokenSettings.Value;
        }

        public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            foreach (var itemRole in roles)
                claims.Add(new Claim(ClaimTypes.Role, itemRole));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Secret));

            var token = new JwtSecurityToken(
                issuer: _tokenSettings.Issuer,
                audience: _tokenSettings.Audience,
                expires: DateTime.Now.AddMinutes(_tokenSettings.TokenValidityInMinutes),
                claims: claims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );




            await _userManager.AddClaimsAsync(user, claims);



            return token;


        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken()
        {
            throw new NotImplementedException();
        }
    }
}

using EcommerceAPI.Application.Bases;
using EcommerceAPI.Application.Features.Auth.Rules;
using EcommerceAPI.Application.Interfaces.AutoMapper;
using EcommerceAPI.Application.Interfaces.Tokens;
using EcommerceAPI.Application.Interfaces.UnitOfWorks;
using EcommerceAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;

        public LoginCommandHandler(IConfiguration configuration,ITokenService tokenService,AuthRules authRules,UserManager<User> userManager,IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor): base(unitOfWork, mapper, contextAccessor) 
        {
            this.configuration = configuration;
            this.tokenService = tokenService;
            this.authRules = authRules;
            this.userManager = userManager;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await userManager.FindByEmailAsync(request.Email);

            bool chackPassword = await userManager.CheckPasswordAsync(user, request.Password);
            await authRules.EmailOrPasswordShouldNotBeInvalid(user, chackPassword);

            IList<string> roles = await userManager.GetRolesAsync(user);

            JwtSecurityToken jwtSecurityToken =await tokenService.CreateToken(user,roles);
            string refreshToken =  tokenService.GenerateRefreshToken();

             _= int.TryParse(configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpriyTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);

            string token = new JwtSecurityTokenHandler ().WriteToken(jwtSecurityToken);

            await userManager.SetAuthenticationTokenAsync(user,"Default","AccessToken",token);

            return new()
            {
                Token = token,
                RefreshToken = refreshToken,
                Expiration = jwtSecurityToken.ValidTo
            };
        }
    }
}

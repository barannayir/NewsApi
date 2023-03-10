using Core.Services.Security.Jwt.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Security.Jwt
{
    public class JwtService : IJwtService
    {
        public IConfiguration Configuration { get; }
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly JwtOptions _options;

        public JwtService(IConfiguration configuration, TokenConfigurations tokenConfigurations )
        {
            Configuration = configuration;
            _tokenConfigurations = tokenConfigurations;
            _options = Configuration.GetSection("JwtOptions").Get<JwtOptions>();
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public JwtToken GenerateJwtToken(User user)
        {

            var userMail = user.Email.ToString();
            var userId = user.Id.ToString();

            var claims = new[]
            {
                new Claim("sub", userId),
                new Claim("mail", userMail),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                audience: _options.Audience,
                issuer: _options.Issuer,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_options.ExpirationInMinutes),
                signingCredentials: _tokenConfigurations.SigningCredentials
            );

            return new JwtToken
            {
                Token = _jwtSecurityTokenHandler.WriteToken(token),
                Expiration = token.ValidTo
            };
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
    }

    }

using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Security.Jwt.Interfaces
{
    public interface IJwtService
    {
        public JwtToken GenerateJwtToken(User user);
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

    }
}

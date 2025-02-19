﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITokenService
    {
        JwtSecurityToken GenerateToken(List<Claim> authClaims);
    }
}

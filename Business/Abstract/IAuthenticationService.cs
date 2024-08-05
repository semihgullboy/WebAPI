using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business.Abstract
{
    public interface IAuthenticationService
    {
        Task<JwtResponse> Login(UserLoginViewModel user);
    }
}

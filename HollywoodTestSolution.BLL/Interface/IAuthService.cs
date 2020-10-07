using HollywoodTestSolution.DM.Request.Authenticate;
using HollywoodTestSolution.DM.Response.Authenticate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.BLL.Interface
{
   public interface IAuthService
    {
        string[] GetRolesForUser(string username);
        AuthResponse AuthenticateUser(AuthRequest authRequest);
    }
}

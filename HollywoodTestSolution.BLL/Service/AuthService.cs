using HollywoodTestSolution.BLL.Interface;
using HollywoodTestSolution.DAL.Interface;
using HollywoodTestSolution.DM.Request.Authenticate;
using HollywoodTestSolution.DM.Response.Authenticate;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.BLL.Service
{
  public  class AuthService:IAuthService
    {
        StandardKernel DependencyKernel;
        public AuthService()
        {
            DependencyKernel = new StandardKernel();
            DependencyKernel.Load(Assembly.GetExecutingAssembly());
        }
        public string[] GetRolesForUser(string username)
        {
            return DependencyKernel.Get<IRoles>().GetRolesForUser(username);
        }
        public AuthResponse AuthenticateUser(AuthRequest authRequest)
        {
            var user = DependencyKernel.Get<IUsers>().GetUser(authRequest.Username, authRequest.Password);
            if (user != null)
                return new AuthResponse(true,"Login Success",user.Id);
            else
                return new AuthResponse(false, "Login Failed");
        }
    }
}

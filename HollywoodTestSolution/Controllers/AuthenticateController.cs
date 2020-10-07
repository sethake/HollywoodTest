using HollywoodTestSolution.BLL.Interface;
using HollywoodTestSolution.DM.Request.Authenticate;
using HollywoodTestSolution.DM.Response.Authenticate;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace HollywoodTestSolution.Controllers
{
    public class AuthenticateController : ApiController
    {
        StandardKernel DependencyKernel;
        public AuthenticateController()
        {
            DependencyKernel = new StandardKernel();
            DependencyKernel.Load(Assembly.GetExecutingAssembly());
        }
        [HttpPost]
        [AllowAnonymous]
        public AuthResponse Authorise(AuthRequest model)
        {
            var authResponse =DependencyKernel.Get<IAuthService>().AuthenticateUser(model);
            return authResponse;
        }
    }
}
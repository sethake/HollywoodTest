using HollywoodTestSolution.BLL.Interface;
using HollywoodTestSolution.BLL.Service;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HollywoodTestSolution
{
    public class Dependencies : NinjectModule
    {
        public override void Load()
        {
            Bind<IEventDetailService>().To<EventDetailService>();
            Bind<IEventService>().To<EventService>();
            Bind<ITournamentService>().To<TournamentService>();
            Bind<IEventDetailStatusService>().To<EventDetailStatusService>();
            Bind<IAuthService>().To<AuthService>();
        }
    }
}
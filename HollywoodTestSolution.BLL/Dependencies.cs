using HollywoodTestSolution.DAL.Interface;
using HollywoodTestSolution.DAL.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.BusinessLogicLayer
{
    public class Dependencies : NinjectModule
    {
        public override void Load()
        {
            Bind<IEvent>().To<EventRepository>();
            Bind<IEventDetail>().To<EventDetailRepository>();
            Bind<IEventDetailStatus>().To<EventDetailStatusRepository>();
            Bind<ITournament>().To<TournamentRepository>();
            Bind<IRoles>().To<RolesRepository>();
            Bind<IUsers>().To<UsersRepository>();
        }
    }
}

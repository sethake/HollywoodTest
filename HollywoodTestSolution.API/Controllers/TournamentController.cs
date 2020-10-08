using HollywoodTestSolution.BLL.Interface;
using HollywoodTestSolution.DM.Request.Tournament;
using HollywoodTestSolution.DM.Response.Tournament;
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
    [BasicAuthentication]
    public class TournamentController : ApiController
    {
        StandardKernel DependencyKernel;
        public TournamentController()
        {
            DependencyKernel = new StandardKernel();
            DependencyKernel.Load(Assembly.GetExecutingAssembly());
        }
        [HttpPost]
        public HttpResponseMessage AddTournament(AddTournamentRequest model)
        {
            
            DependencyKernel.Get<ITournamentService>().AddTournament(model);
            return Request.CreateResponse(HttpStatusCode.OK, $"The Tournament {model.TournamentName} has been created Succesfully");
        }
        [HttpPut]
        public HttpResponseMessage UpdateTournament(UpdateTournamentRequest model)
        {
            DependencyKernel.Get<ITournamentService>().UpdateTournament(model);
            return Request.CreateResponse(HttpStatusCode.OK, $"The Tournament has been Updated Succesfully");
        }
        [HttpDelete]
        public HttpResponseMessage DeleteTournament(long tournamentId)
        {
            DependencyKernel.Get<ITournamentService>().DeleteTournament(tournamentId);
            return Request.CreateResponse(HttpStatusCode.OK, $"The Tournament has been Deleted Succesfully");
        }
        [HttpGet]
        public List<TournamentResponse> GetTournaments()
        {
            return DependencyKernel.Get<ITournamentService>().GetTournaments();
        }

    }
}
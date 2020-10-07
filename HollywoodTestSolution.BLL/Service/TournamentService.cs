using HollywoodTestSolution.BLL.Interface;
using HollywoodTestSolution.DAL.Interface;
using HollywoodTestSolution.DM.Request.Tournament;
using HollywoodTestSolution.DM.Response.Tournament;
using Newtonsoft.Json;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.BLL.Service
{
    public class TournamentService : ITournamentService
    {
        StandardKernel DependencyKernel;
        public TournamentService()
        {
            DependencyKernel = new StandardKernel();
            DependencyKernel.Load(Assembly.GetExecutingAssembly());
        }
        public long AddTournament(AddTournamentRequest model)
        {
            if (DependencyKernel.Get<ITournament>().TournamentExists(model.TournamentName))
                throw new Exception($"Tournament with name {model.TournamentName} already exists");
            var tournament = new DAL.DBML.Tournament { TournamentName = model.TournamentName };
            long tournamentId = DependencyKernel.Get<ITournament>().Create(tournament);
            return tournamentId;
        }
        public void UpdateTournament(UpdateTournamentRequest model)
        {
            var tournament = JsonConvert.DeserializeObject<DAL.DBML.Tournament>(JsonConvert.SerializeObject(model));
            DependencyKernel.Get<ITournament>().Update(tournament);
        }
        public void DeleteTournament(long tournamentId)
        {
            DependencyKernel.Get<ITournament>().Delete(tournamentId);
        }
        public List<TournamentResponse> GetTournaments()
        {
            var tournaments = DependencyKernel.Get<ITournament>().GetTournaments();
            return JsonConvert.DeserializeObject<List<TournamentResponse>>(JsonConvert.SerializeObject(tournaments));
        }
    }
}

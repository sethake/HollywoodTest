using HollywoodTestSolution.DM.Request.Tournament;
using HollywoodTestSolution.DM.Response.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.BLL.Interface
{
    public interface ITournamentService
    {
        long AddTournament(AddTournamentRequest model);
        void UpdateTournament(UpdateTournamentRequest model);
        void DeleteTournament(long tournamentId);
        List<TournamentResponse> GetTournaments();
    }
}

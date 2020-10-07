using HollywoodTestSolution.DAL.DBML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.DAL.Interface
{
   public interface ITournament
    {
        long Create(Tournament tournament);
        void Update(Tournament tournament);
        void Delete(long tournamentId);
        List<Tournament> GetTournaments();
        bool TournamentExists(string tournamentName);
    }
}

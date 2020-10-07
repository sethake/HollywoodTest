using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HollywoodTestSolution.DAL.Interface;
using HollywoodTestSolution.DAL.DBML;

namespace HollywoodTestSolution.DAL.Repository
{
   public class TournamentRepository: ITournament
    {
        public long Create(Tournament tournament)
        {
            using(HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                db.Tournaments.InsertOnSubmit(tournament);
                db.SubmitChanges();
                return tournament.TournamentID;
            }
        }
        public void Update(Tournament tournament)
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var currentTournament = (from T in db.Tournaments where T.TournamentID == tournament.TournamentID select T).FirstOrDefault();
                currentTournament.TournamentName = tournament.TournamentName;
                db.SubmitChanges();
            }
        }
        public void Delete(long tournamentId)
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var tournament = (from T in db.Tournaments where T.TournamentID == tournamentId select T).FirstOrDefault();
                db.Tournaments.DeleteOnSubmit(tournament);
                db.SubmitChanges();
            }
        }
        public List<Tournament> GetTournaments()
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var tournaments = (from T in db.Tournaments select T).ToList();
                return tournaments;
            }
        }
        public bool TournamentExists(string tournamentName)
        {
            bool exists = false;
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var tournament = (from T in db.Tournaments where T.TournamentName.ToLower() == tournamentName.ToLower() select T).FirstOrDefault();
                if (tournament != null)
                    exists = true;
            }
            return exists;
        }
    }
}

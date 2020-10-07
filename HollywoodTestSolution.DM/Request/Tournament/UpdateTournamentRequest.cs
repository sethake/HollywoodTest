using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.DM.Request.Tournament
{
   public class UpdateTournamentRequest
    {
        public long TournamentID { get; set; }
        public string TournamentName { get; set; }
    }
}

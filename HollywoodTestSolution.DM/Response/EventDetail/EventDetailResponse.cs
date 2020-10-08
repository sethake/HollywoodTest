using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.DM.Response.EventDetail
{
   public class EventDetailResponse
    {
        public long FK_TournamentID { get; set; }
        public string Tournament { get; set; }
        public string Event { get; set; }
        public long EventDetailID { get; set; }
        public long FK_EventID { get; set; }
        public string Status { get; set; }
        public long FK_EventDetailStatusID { get; set; }
        public string EventDetailName { get; set; }
        public int EventDetailNumber { get; set; }
        public decimal EventDetailOdd { get; set; }
        public int FinishingPosition { get; set; }
        public bool FirstTimer { get; set; }
    }
}

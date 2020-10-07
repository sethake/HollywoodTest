using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.DM.Request.Event
{
    public class UpdateEventRequest
    {
        public long FK_TournamentID { get; set; }
        public long EventID { get; set; }
        public string EventName { get; set; }
        public int EventNumber { get; set; }
        public DateTime EventDateTime { get; set; }
        public DateTime EventEndDateTime { get; set; }
        public bool AutoClose { get; set; }
    }
}

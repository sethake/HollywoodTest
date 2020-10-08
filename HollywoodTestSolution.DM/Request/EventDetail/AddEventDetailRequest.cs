using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.DM.Request.EventDetail
{
    public class AddEventDetailRequest
    {
        public long FK_EventID { get; set; }
        public long FK_EventDetailStatusID { get; set; }
        public string EventDetailName { get; set; }
        public int EventDetailNumber { get; set; }
        public decimal EventDetailOdd { get; set; }
        public int FinishingPosition { get; set; }
        public bool FirstTimer { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.DM.Request.Event
{
    public class UpdateEventRequest:AddEventRequest
    {
        public long EventID { get; set; }
    }
}

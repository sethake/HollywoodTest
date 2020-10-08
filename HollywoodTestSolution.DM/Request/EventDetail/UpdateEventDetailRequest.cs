using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.DM.Request.EventDetail
{
   public class UpdateEventDetailRequest:AddEventDetailRequest
    {
        public int EventDetailID { get; set; }
    }
}

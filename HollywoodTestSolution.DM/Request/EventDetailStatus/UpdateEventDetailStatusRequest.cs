using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.DM.Request.EventDetailStatus
{
  public  class UpdateEventDetailStatusRequest:AddEventDetailStatusRequest
    {
        public long EventDetailStatusID { get; set; }
    }
}

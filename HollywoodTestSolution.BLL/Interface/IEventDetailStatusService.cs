using HollywoodTestSolution.DM.Request.EventDetailStatus;
using HollywoodTestSolution.DM.Response.EventDetailStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.BLL.Interface
{
   public interface IEventDetailStatusService
    {
        long AddEventDetailStatus(AddEventDetailStatusRequest model);
        void UpdateEventDetailStatus(UpdateEventDetailStatusRequest model);
        void DeleteEventDetailStatus(long EventDetailStatusId);
        List<EventDetailStatusResponse> GetEventDetailStatuses();
        
    }
}

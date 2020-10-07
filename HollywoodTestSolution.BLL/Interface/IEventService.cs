using HollywoodTestSolution.DM.Request.Event;
using HollywoodTestSolution.DM.Response.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.BLL.Interface
{
   public interface IEventService
    {
        long AddEvent(AddEventRequest model);
        void UpdateEvent(UpdateEventRequest model);
        void DeleteEvents(DeleteEventRequest model);
        List<EventResponse> GetEvents();


    }
}

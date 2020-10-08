using HollywoodTestSolution.DM.Request.EventDetail;
using HollywoodTestSolution.DM.Response.EventDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.BLL.Interface
{
   public interface IEventDetailService
    {
        long AddEventDetail(AddEventDetailRequest model);
        void UpdateEventDetail(UpdateEventDetailRequest model);
        void DeleteEventDetails(DeleteEventDetailRequest model);
        List<EventDetailResponse> GetEventDetails(int eventId);
    }
}

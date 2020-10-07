using HollywoodTestSolution.DAL.DBML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.DAL.Interface
{
   public interface IEventDetail
    {
        long Create(EventDetail eventDetail);
        void Update(EventDetail eventDetail);
        void Delete(long eventDetailId);
        void Delete(List<long> eventdetailIds);
        List<EventDetail> GetEventDetails(long eventId);
      
    }
}

using HollywoodTestSolution.DAL.DBML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.DAL.Interface
{
   public interface IEventDetailStatus
    {
        long Create(EventDetailStatus EventDetailStatus);
        void Update(EventDetailStatus EventDetailStatus);
        void Delete(long EventDetailStatusId);
        List<EventDetailStatus> GetEventDetailStatuses();
        bool EventDetailStatusExists(string eventDetailStatusName);
    }
}

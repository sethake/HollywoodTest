using HollywoodTestSolution.DAL.DBML;
using HollywoodTestSolution.DM.Response.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.DAL.Interface
{
    public interface IEvent
    {
        long Create(Event @event);
        void Update(Event @event);
        void Delete(long eventId);
        void Delete(List<long> eventIds);
        List<Event> GetEvents();
        List<EventResponse> GetEventsResponse();
        List<EventResponse> GetEventsResponse(int tournamentId);
        bool EventExists(string eventName);
    }
}

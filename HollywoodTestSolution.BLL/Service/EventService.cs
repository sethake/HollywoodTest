using HollywoodTestSolution.BLL.Interface;
using HollywoodTestSolution.DAL.Interface;
using HollywoodTestSolution.DM.Request.Event;
using HollywoodTestSolution.DM.Response.Event;
using Newtonsoft.Json;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.BLL.Service
{
    public class EventService : IEventService
    {
        StandardKernel DependencyKernel;
        public EventService()
        {
            DependencyKernel = new StandardKernel();
            DependencyKernel.Load(Assembly.GetExecutingAssembly());
        }
        public long AddEvent(AddEventRequest model)
        {
            if (DependencyKernel.Get<IEvent>().EventExists(model.EventName))
                throw new Exception($"Event with name {model.EventName} already exists");
            var @event = JsonConvert.DeserializeObject<DAL.DBML.Event>(JsonConvert.SerializeObject(model));
            long eventId = DependencyKernel.Get<IEvent>().Create(@event);
            return eventId;
        }
        public void UpdateEvent(UpdateEventRequest model)
        {
            var @event = JsonConvert.DeserializeObject<DAL.DBML.Event>(JsonConvert.SerializeObject(model));
            DependencyKernel.Get<IEvent>().Update(@event);
        }
        public void DeleteEvents(DeleteEventRequest model)
        {
            if(model.EventIDs.Count == 1)
            DependencyKernel.Get<IEvent>().Delete(model.EventIDs.First());
            if(model.EventIDs.Count > 1)
                DependencyKernel.Get<IEvent>().Delete(model.EventIDs);
        }
        public List<EventResponse> GetEvents()
        {
            var events = DependencyKernel.Get<IEvent>().GetEventsResponse();
            return events;
        }
    }
}

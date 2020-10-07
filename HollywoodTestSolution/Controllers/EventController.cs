using HollywoodTestSolution.BLL.Interface;
using HollywoodTestSolution.DM.Request.Event;
using HollywoodTestSolution.DM.Response.Event;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace HollywoodTestSolution.Controllers
{
    [BasicAuthentication]
    public class EventController : ApiController
    {
        StandardKernel DependencyKernel;
        public EventController()
        {
            DependencyKernel = new StandardKernel();
            DependencyKernel.Load(Assembly.GetExecutingAssembly());
        }
        [HttpPost]
        public HttpResponseMessage AddEvent(AddEventRequest model)
        {
            DependencyKernel.Get<IEventService>().AddEvent(model);
            return Request.CreateResponse(HttpStatusCode.OK, $"The Event {model.EventName} has been created Succesfully");
        }
        [HttpPut]
        public HttpResponseMessage UpdateEvent(UpdateEventRequest model)
        {
            DependencyKernel.Get<IEventService>().UpdateEvent(model);
            return Request.CreateResponse(HttpStatusCode.OK, $"The Event has been Updated Succesfully");
        }
        [HttpDelete]
        public HttpResponseMessage DeleteEvents(DeleteEventRequest model)
        {
            DependencyKernel.Get<IEventService>().DeleteEvents(model);
            return Request.CreateResponse(HttpStatusCode.OK, $"The Event has been Deleted Succesfully");
        }
        [HttpGet]
        public List<EventResponse> GetEvents()
        {
            return DependencyKernel.Get<IEventService>().GetEvents();
        }
    }
}
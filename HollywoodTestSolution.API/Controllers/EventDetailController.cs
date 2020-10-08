using HollywoodTestSolution.BLL.Interface;
using HollywoodTestSolution.DM.Request.EventDetail;
using HollywoodTestSolution.DM.Response.EventDetail;
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
    public class EventDetailController : ApiController
    {
        StandardKernel DependencyKernel;
        public EventDetailController()
        {
            DependencyKernel = new StandardKernel();
            DependencyKernel.Load(Assembly.GetExecutingAssembly());
        }
        [HttpPost]
        public HttpResponseMessage AddEventDetail(AddEventDetailRequest model)
        {
            DependencyKernel.Get<IEventDetailService>().AddEventDetail(model);
            return Request.CreateResponse(HttpStatusCode.OK, $"The EventDetail {model.EventDetailName} has been created Succesfully");
        }
        [HttpPut]
        public HttpResponseMessage UpdateEventDetail(UpdateEventDetailRequest model)
        {
            DependencyKernel.Get<IEventDetailService>().UpdateEventDetail(model);
            return Request.CreateResponse(HttpStatusCode.OK, $"The EventDetail has been Updated Succesfully");
        }
        [HttpDelete]
        public HttpResponseMessage DeleteEventDetails(DeleteEventDetailRequest model)
        {
            DependencyKernel.Get<IEventDetailService>().DeleteEventDetails(model);
            return Request.CreateResponse(HttpStatusCode.OK, $"The EventDetail has been Deleted Succesfully");
        }
        [HttpGet]
        public List<EventDetailResponse> GetEventDetails(int eventId)
        {
            return DependencyKernel.Get<IEventDetailService>().GetEventDetails(eventId);
        }
    }
}
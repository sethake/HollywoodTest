using HollywoodTestSolution.BLL.Interface;
using HollywoodTestSolution.DM.Request.EventDetailStatus;
using HollywoodTestSolution.DM.Response.EventDetailStatus;
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
    public class EventDetailStatusController : ApiController
    {
        StandardKernel DependencyKernel;
        public EventDetailStatusController()
        {
            DependencyKernel = new StandardKernel();
            DependencyKernel.Load(Assembly.GetExecutingAssembly());
        }
        [HttpPost]
        public HttpResponseMessage AddEventDetailStatus(AddEventDetailStatusRequest model)
        {

            DependencyKernel.Get<IEventDetailStatusService>().AddEventDetailStatus(model);
            return Request.CreateResponse(HttpStatusCode.OK, $"The EventDetailStatus {model.EventDetailStatusName} has been created Succesfully");
        }
        [HttpPut]
        public HttpResponseMessage UpdateEventDetailStatus(UpdateEventDetailStatusRequest model)
        {
            DependencyKernel.Get<IEventDetailStatusService>().UpdateEventDetailStatus(model);
            return Request.CreateResponse(HttpStatusCode.OK, $"The EventDetailStatus has been Updated Succesfully");
        }
        [HttpDelete]
        public HttpResponseMessage DeleteEventDetailStatus(long EventDetailStatusId)
        {
            DependencyKernel.Get<IEventDetailStatusService>().DeleteEventDetailStatus(EventDetailStatusId);
            return Request.CreateResponse(HttpStatusCode.OK, $"The EventDetailStatus has been Deleted Succesfully");
        }
        [HttpGet]
        public List<EventDetailStatusResponse> GetEventDetailStatuss()
        {
            return DependencyKernel.Get<IEventDetailStatusService>().GetEventDetailStatuses();
        }
    }
}
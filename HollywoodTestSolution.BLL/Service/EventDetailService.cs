using HollywoodTestSolution.BLL.Interface;
using HollywoodTestSolution.DAL.Interface;
using HollywoodTestSolution.DM.Request.EventDetail;
using HollywoodTestSolution.DM.Response.EventDetail;
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
   public class EventDetailService:IEventDetailService
    {
        StandardKernel DependencyKernel;
        public EventDetailService()
        {
            DependencyKernel = new StandardKernel();
            DependencyKernel.Load(Assembly.GetExecutingAssembly());
        }
        public long AddEventDetail(AddEventDetailRequest model)
        {
            if (DependencyKernel.Get<IEventDetail>().EventDetailExists(model.EventDetailName))
                throw new Exception($"EventDetail with name {model.EventDetailName} already exists");
            var @EventDetail = JsonConvert.DeserializeObject<DAL.DBML.EventDetail>(JsonConvert.SerializeObject(model));
            long EventDetailId = DependencyKernel.Get<IEventDetail>().Create(@EventDetail);
            return EventDetailId;
        }
        public void UpdateEventDetail(UpdateEventDetailRequest model)
        {
            var @EventDetail = JsonConvert.DeserializeObject<DAL.DBML.EventDetail>(JsonConvert.SerializeObject(model));
            DependencyKernel.Get<IEventDetail>().Update(@EventDetail);
        }
        public void DeleteEventDetails(DeleteEventDetailRequest model)
        {
            if (model.EventDetailIDs.Count == 1)
                DependencyKernel.Get<IEventDetail>().Delete(model.EventDetailIDs.First());
            if (model.EventDetailIDs.Count > 1)
                DependencyKernel.Get<IEventDetail>().Delete(model.EventDetailIDs);
        }
        public List<EventDetailResponse> GetEventDetails(int eventId)
        {
            List<EventDetailResponse> EventDetails = new List<EventDetailResponse>();
            if (eventId > 0)
                EventDetails = DependencyKernel.Get<IEventDetail>().GetEventDetailsResponse(eventId);
            else
                EventDetails = DependencyKernel.Get<IEventDetail>().GetEventDetailsResponse();
            return EventDetails;
        }
    }
}

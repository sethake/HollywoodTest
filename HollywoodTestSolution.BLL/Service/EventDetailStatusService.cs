using HollywoodTestSolution.BLL.Interface;
using HollywoodTestSolution.DAL.Interface;
using HollywoodTestSolution.DM.Request.EventDetailStatus;
using HollywoodTestSolution.DM.Response.EventDetailStatus;
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
   public class EventDetailStatusService: IEventDetailStatusService
    {
        StandardKernel DependencyKernel;
        public EventDetailStatusService()
        {
            DependencyKernel = new StandardKernel();
            DependencyKernel.Load(Assembly.GetExecutingAssembly());
        }
        public long AddEventDetailStatus(AddEventDetailStatusRequest model)
        {
            if (DependencyKernel.Get<IEventDetailStatus>().EventDetailStatusExists(model.EventDetailStatusName))
                throw new Exception($"EventDetailStatus with name {model.EventDetailStatusName} already exists");
            var EventDetailStatus = new DAL.DBML.EventDetailStatus { EventDetailStatusName = model.EventDetailStatusName };
            long EventDetailStatusId = DependencyKernel.Get<IEventDetailStatus>().Create(EventDetailStatus);
            return EventDetailStatusId;
        }
        public void UpdateEventDetailStatus(UpdateEventDetailStatusRequest model)
        {
            var EventDetailStatus = JsonConvert.DeserializeObject<DAL.DBML.EventDetailStatus>(JsonConvert.SerializeObject(model));
            DependencyKernel.Get<IEventDetailStatus>().Update(EventDetailStatus);
        }
        public void DeleteEventDetailStatus(long EventDetailStatusId)
        {
            DependencyKernel.Get<IEventDetailStatus>().Delete(EventDetailStatusId);
        }
        public List<EventDetailStatusResponse> GetEventDetailStatuses()
        {
            var EventDetailStatuss = DependencyKernel.Get<IEventDetailStatus>().GetEventDetailStatuses();
            return JsonConvert.DeserializeObject<List<EventDetailStatusResponse>>(JsonConvert.SerializeObject(EventDetailStatuss));
        }
    }
}

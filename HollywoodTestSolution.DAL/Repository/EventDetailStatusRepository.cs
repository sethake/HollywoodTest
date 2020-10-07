using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HollywoodTestSolution.DAL.DBML;
using HollywoodTestSolution.DAL.Interface;
namespace HollywoodTestSolution.DAL.Repository
{
   public class EventDetailStatusRepository: IEventDetailStatus
    {
        public List<EventDetailStatus> GetEventDetailStatuses()
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var eventDetailStatuses = (from EDS in db.EventDetailStatus select EDS).ToList();
                return eventDetailStatuses;
            }
        }
    }
}

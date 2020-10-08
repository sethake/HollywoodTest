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
        public long Create(EventDetailStatus EventDetailStatus)
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                db.EventDetailStatus.InsertOnSubmit(EventDetailStatus);
                db.SubmitChanges();
                return EventDetailStatus.EventDetailStatusID;
            }
        }
        public void Update(EventDetailStatus EventDetailStatus)
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var currentEventDetailStatus = (from EDS in db.EventDetailStatus where EDS.EventDetailStatusID == EventDetailStatus.EventDetailStatusID select EDS).FirstOrDefault();
                currentEventDetailStatus.EventDetailStatusName = EventDetailStatus.EventDetailStatusName;
                db.SubmitChanges();
            }
        }
        public void Delete(long EventDetailStatusId)
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var EventDetailStatus = (from EDS in db.EventDetailStatus where EDS.EventDetailStatusID == EventDetailStatusId select EDS).FirstOrDefault();
                db.EventDetailStatus.DeleteOnSubmit(EventDetailStatus);
                db.SubmitChanges();
            }
        }
        public List<EventDetailStatus> GetEventDetailStatuses()
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var eventDetailStatuses = (from EDS in db.EventDetailStatus select EDS).ToList();
                return eventDetailStatuses;
            }
        }
        public bool EventDetailStatusExists(string eventDetailStatusName)
        {
            bool exists = false;
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var eventDetailStatus = (from EDS in db.EventDetailStatus where EDS.EventDetailStatusName.ToLower() == eventDetailStatusName.ToLower() select EDS).FirstOrDefault();
                if (eventDetailStatus != null)
                    exists = true;
            }
            return exists;
        }
    }
}

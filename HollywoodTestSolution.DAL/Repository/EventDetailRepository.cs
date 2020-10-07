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
   public class EventDetailRepository: IEventDetail
    {
        public long Create(EventDetail eventDetail)
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                db.EventDetails.InsertOnSubmit(eventDetail);
                db.SubmitChanges();
                return eventDetail.EventDetailID;
            }
        }
        public void Update(EventDetail eventDetail)
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var currentEventDetail = (from ED in db.EventDetails where ED.EventDetailID == eventDetail.EventDetailID select ED).FirstOrDefault();
                currentEventDetail.FK_EventDetailStatusID = eventDetail.FK_EventDetailStatusID;
                currentEventDetail.EventDetailName = eventDetail.EventDetailName;
                currentEventDetail.EventDetailNumber = eventDetail.EventDetailNumber;
                currentEventDetail.EventDetailOdd = eventDetail.EventDetailOdd;
                currentEventDetail.FinishingPosition = eventDetail.FinishingPosition;
                currentEventDetail.FirstTimer = eventDetail.FirstTimer;
                db.SubmitChanges();
            }
        }
        public void Delete(long eventDetailId)
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var eventDetail = (from ED in db.EventDetails where ED.EventDetailID == eventDetailId select ED).FirstOrDefault();
                db.EventDetails.DeleteOnSubmit(eventDetail);
                db.SubmitChanges();
            }
        }
        public void Delete(List<long> eventdetailIds)
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var eventDetails = (from ED in db.EventDetails where eventdetailIds.Contains(ED.EventDetailID) select ED).ToList();
                db.EventDetails.DeleteAllOnSubmit(eventDetails);
                db.SubmitChanges();
            }
        }
        public List<EventDetail> GetEventDetails(long eventId)
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var eventDetails = (from ED in db.EventDetails where ED.FK_EventID == eventId select ED).ToList();
                return eventDetails;
            }
        }
    }
}

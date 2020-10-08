using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HollywoodTestSolution.DAL.DBML;
using HollywoodTestSolution.DAL.Interface;
using HollywoodTestSolution.DM.Response.EventDetail;

namespace HollywoodTestSolution.DAL.Repository
{
    public class EventDetailRepository : IEventDetail
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
        public List<EventDetailResponse> GetEventDetailsResponse()
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var eventDetails = (from ED in db.EventDetails
                                    join E in db.Events on ED.FK_EventID equals E.EventID
                                    join EDS in db.EventDetailStatus on ED.FK_EventDetailStatusID equals EDS.EventDetailStatusID
                                    join T in db.Tournaments on E.FK_TournamentID equals T.TournamentID
                                    orderby E.FK_TournamentID, ED.FK_EventID
                                    select new EventDetailResponse
                                    {
                                        FK_EventID = ED.FK_EventID.Value,
                                        EventDetailID = ED.EventDetailID,
                                        EventDetailName = ED.EventDetailName,
                                        EventDetailNumber = ED.EventDetailNumber.Value,
                                        EventDetailOdd = ED.EventDetailOdd.Value,
                                        FinishingPosition = ED.FinishingPosition.Value,
                                        FirstTimer = ED.FirstTimer ?? false,
                                        FK_EventDetailStatusID = ED.FK_EventDetailStatusID.Value,
                                        Event = E.EventName,
                                        Tournament = T.TournamentName,
                                        Status = EDS.EventDetailStatusName,
                                        FK_TournamentID = T.TournamentID
                                    }).ToList();
                return eventDetails;
            }
        }
        public List<EventDetailResponse> GetEventDetailsResponse(int eventId)
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var eventDetails = (from ED in db.EventDetails
                                    join E in db.Events on ED.FK_EventID equals E.EventID
                                    join EDS in db.EventDetailStatus on ED.FK_EventDetailStatusID equals EDS.EventDetailStatusID
                                    join T in db.Tournaments on E.FK_TournamentID equals T.TournamentID
                                    where ED.FK_EventID == eventId
                                    orderby E.FK_TournamentID, ED.FK_EventID
                                    select new EventDetailResponse
                                    {
                                        FK_EventID = ED.FK_EventID.Value,
                                        EventDetailID = ED.EventDetailID,
                                        EventDetailName = ED.EventDetailName,
                                        EventDetailNumber = ED.EventDetailNumber.Value,
                                        EventDetailOdd = ED.EventDetailOdd.Value,
                                        FinishingPosition = ED.FinishingPosition.Value,
                                        FirstTimer = ED.FirstTimer ?? false,
                                        FK_EventDetailStatusID = ED.FK_EventDetailStatusID.Value,
                                        Event = E.EventName,
                                        Tournament = T.TournamentName,
                                        Status = EDS.EventDetailStatusName,
                                        FK_TournamentID = T.TournamentID
                                    }).ToList();
                return eventDetails;
            }
        }
        public bool EventDetailExists(string eventDetailName)
        {
            bool exists = false;
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var eventDetail = (from ED in db.EventDetails where ED.EventDetailName.ToLower() == eventDetailName.ToLower() select ED).FirstOrDefault();
                if (eventDetail != null)
                    exists = true;
            }
            return exists;
        }
    }
}

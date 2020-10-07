using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HollywoodTestSolution.DAL.DBML;
using HollywoodTestSolution.DAL.Interface;
using HollywoodTestSolution.DM.Response.Event;

namespace HollywoodTestSolution.DAL.Repository
{
    public class EventRepository : IEvent
    {
        public long Create(Event @event)
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                db.Events.InsertOnSubmit(@event);
                db.SubmitChanges();
                return @event.EventID;
            }
        }
        public void Update(Event @event)
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var currentEvent = (from E in db.Events where E.EventID == @event.EventID select E).FirstOrDefault();
                currentEvent.FK_TournamentID = @event.FK_TournamentID;
                currentEvent.EventName = @event.EventName;
                currentEvent.EventNumber = @event.EventNumber;
                currentEvent.EventDateTime = @event.EventDateTime;
                currentEvent.EventEndDateTime = @event.EventEndDateTime;
                currentEvent.AutoClose = @event.AutoClose;
                db.SubmitChanges();
            }
        }
        public void Delete(long eventId)
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var @event = (from E in db.Events where E.EventID == eventId select E).FirstOrDefault();
                db.Events.DeleteOnSubmit(@event);
                db.SubmitChanges();
            }
        }
        public void Delete(List<long> eventIds)
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var events = (from E in db.Events where eventIds.Contains(E.EventID) select E).ToList();
                db.Events.DeleteAllOnSubmit(events);
                db.SubmitChanges();
            }
        }
        public List<Event> GetEvents()
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var events = (from E in db.Events orderby E.FK_TournamentID select E).ToList();
                return events;
            }
        }
        public List<EventResponse> GetEventsResponse()
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var events = (from E in db.Events
                              join T in db.Tournaments on E.FK_TournamentID equals T.TournamentID
                              orderby E.FK_TournamentID
                              select new EventResponse
                              {
                                  AutoClose = E.AutoClose??false,
                                  EventDateTime = E.EventDateTime.Value,
                                 EventEndDateTime = E.EventEndDateTime.Value,
                                 EventID = E.EventID,
                                  EventName = E.EventName,
                                 EventNumber = E.EventNumber.Value,
                                 FK_TournamentID = E.FK_TournamentID.Value,
                                 Tournament = T.TournamentName
                              }).ToList();
                return events;
            }
        }
        public bool EventExists(string eventName)
        {
            bool exists = false;
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                db.DeferredLoadingEnabled = false;
                var @event = (from E in db.Events where E.EventName.ToLower() == eventName.ToLower() select E).FirstOrDefault();
                if (@event != null)
                    exists = true;
            }
            return exists;
        }
    }
}

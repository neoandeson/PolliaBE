using DataLayer.Infrastucture;
using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Event GetById(int? EventId)
        {
            if (EventId != null)
            {
                Event Event = this.DbContext.Events.Where(p => p.Id == EventId).FirstOrDefault();
                return Event;
            }
            return null;
        }

        public Event GetEventByAddress(string address)
        {
            Event Event = this.DbContext.Events.Where(p => p.Place.Address.Contains(address) ).FirstOrDefault();
            return Event;
        }

        public Event GetEventByName(string eventName)
        {
            Event Event = this.DbContext.Events.Where(p => p.Title.Contains(eventName)).FirstOrDefault();
            return Event;
        }

        //public List<Event> GetEventNearBy(float longitude, float latitude, float distance, int scope)
        //{
        //    List<Event> Events = this.DbContext.Events.Where(p => ((Math.Abs((p.Longitude - longitude)) < distance) && (Math.Abs((p.Latitude - latitude)) < distance)) && (p.EventKindId == scope)).Take(20).ToList();
        //    return Events;
        //}

        public IEnumerable<Event> GetEventsByName(string EventName, int curr, int take)
        {
            IEnumerable<Event> Events = this.DbContext.Events.Where(p => p.Title.Contains(EventName)).OrderBy(p => p.NofSearch).Skip(curr).Take(take);
            return Events;
        }

        public int GetTotalEvents()
        {
            return this.DbContext.Events.Count();
        }

        public int GetTotalEventsOf(List<string> args)
        {
            return this.DbContext.Events.Where(e => args.Contains(e.UserId)).Count();
        }
    }

    public interface IEventRepository : IRepository<Event>
    {
        Event GetEventByAddress(string address);
        Event GetEventByName(string EventName);
        IEnumerable<Event> GetEventsByName(string EventName, int curr, int take);
        //List<Event> GetEventNearBy(float longitude, float latitude, float distance, int scope);
        Event GetById(int? EventId);
        int GetTotalEvents();
        int GetTotalEventsOf(List<string> args);
    }
}

using DataLayer.Infrastucture;
using DataLayer.Repositories;
using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface IEventService
    {
        IEnumerable<Event> GetEvents(string name = null);
        Event GetEvent(int id);
        Event GetEvent(string name);
        Event GetEventByAddress(string address);
        void CreateEvent(Event Event);
        void EditEvent(Event Event);
        void RemoveEvent(int id);
        void SaveEvent();
        void UnRemoveEvent(int id);
        Event GetEvent(int? EventId);
        //List<Event> GetEventsNearBy(float longitude, float latitude, float distance, int scope);
        IEnumerable<Event> GetEventsByName(string name, int curr, int take);
        int GetTotalEvents();
        int GetTotalEventOf(List<string> args);
    }

    public class EventService : IEventService
    {
        private readonly IEventRepository EventRepository;
        private readonly IUnitOfWork unitOfWork;

        public EventService(IEventRepository EventRepository, IUnitOfWork unitOfWork)
        {
            this.EventRepository = EventRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateEvent(Event Event)
        {
            EventRepository.Add(Event);
            SaveEvent();
        }

        public void EditEvent(Event Event)
        {
            EventRepository.Update(Event);
            SaveEvent();
        }

        public Event GetEvent(int id)
        {
            var Event = EventRepository.GetById(id);
            return Event;
        }

        public Event GetEvent(string name)
        {
            var Event = EventRepository.GetEventByName(name);
            return Event;
        }

        public Event GetEvent(int? EventId)
        {
            if (EventId != null)
            {
                var Event = EventRepository.GetById((int)EventId);
                return Event;
            }
            return null;
        }

        public Event GetEventByAddress(string address)
        {
            Event Event = EventRepository.GetEventByAddress(address);
            return Event;
        }

        public IEnumerable<Event> GetEvents(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return EventRepository.GetAll();
            else
                return EventRepository.GetAll().Where(c => c.Title.Contains(name));
        }

        public IEnumerable<Event> GetEventsByName(string name, int curr, int take)
        {
            if (string.IsNullOrEmpty(name))
                return null;
            else
                return EventRepository.GetEventsByName(name, curr, take);
        }

        public int GetTotalEventOf(List<string> args)
        {
            if(args != null)
            {
                return EventRepository.GetTotalEventsOf(args);
            }
            return 0;
        }

        public int GetTotalEvents()
        {
            return EventRepository.GetTotalEvents();
        }

        //public List<Event> GetEventsNearBy(float longitude, float latitude, float distance, int scope)
        //{
        //    return EventRepository.GetEventNearBy(longitude, latitude, distance, scope);
        //}

        public void RemoveEvent(int id)
        {
            Event p = EventRepository.GetById(id);
            p.ServeStatus = 0;
            EventRepository.Update(p);
            SaveEvent();
        }

        public void SaveEvent()
        {
            unitOfWork.Commit();
        }

        public void UnRemoveEvent(int id)
        {
            Event p = EventRepository.GetById(id);
            p.ServeStatus = 1;
            EventRepository.Update(p);
            SaveEvent();
        }
    }
}

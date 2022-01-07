using CodingEventsAgain.Models;
using System.Collections.Generic;
using System.Linq;

namespace CodingEventsAgain.Data
{
    public class EventData
    {
        static private Dictionary<int, Event> Events;

        // GetAll
        public static List<Event> GetAll()
        {
            if(Events is null)
            {
                return null;
            }
            IEnumerable<Event> eventsIter = Events.Values;
            if(!(eventsIter is null))
            {
                return eventsIter.ToList();
            } 
            else
            {
                return null;
            }
        }

        // Add
        public static void Add(Event newEvent)
        {
            if(Events is null)
            {
                Events = new Dictionary<int, Event>();
            }
            Events.Add(newEvent.Uid, newEvent);
        }

        // Remove
        public static void Remove(int id)
        {
            Events.Remove(id);
        }

        // GetById
        public static Event GetById(int id)
        {
            return Events[id];
        }
    }
}

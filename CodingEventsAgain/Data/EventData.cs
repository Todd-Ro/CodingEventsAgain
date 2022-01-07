using CodingEventsAgain.Models;
using System.Collections.Generic;
using System.Linq;

namespace CodingEventsAgain.Data
{
    public class EventData
    {
        static private Dictionary<int, Event> Events;

        public static List<Event> OrderValuesByKey(Dictionary<int, Event> myDict)
        {
            IEnumerable<KeyValuePair<int, Event>> sorted = myDict.OrderBy(x => x.Key);
            List<Event> valuesSortedByKey = new List<Event>();
            foreach (KeyValuePair<int, Event> kvp in sorted)
            {
                valuesSortedByKey.Add(kvp.Value);
            }
            return valuesSortedByKey;
        }

        static private Dictionary<string, string> EventDict;
        internal static void InitializeEventDict()
        {
            if (EventDict is null)
            {
                EventDict = new Dictionary<string, string>();
                EventDict.Add("Virtual Coding Conference",
                    "Helps prepare for coding in the new year");
                EventDict.Add("Women in Coding", "Discussion of History");
                EventDict.Add("GlobalHack Intro to Coding Workshop", "Learning resource for young people");
            }

            List<Event> checkList = EventData.GetAll();
            if (checkList is null)
            {
                Events = new Dictionary<int, Event>();
                foreach (string eventName in EventDict.Keys)
                {
                    Event e = new Event(eventName, EventDict[eventName]);
                    EventData.Add(e);
                }
                //Event.MakeInitialized();
                //Event.MakeThreeFirstDone();
            }
        }

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
                return OrderValuesByKey(Events);
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
                InitializeEventDict();
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

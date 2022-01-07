using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodingEventsAgain.Controllers
{
    public class EventsController : Controller
    {
        static private List<string> EventList;
        static private Dictionary<string, string> EventDict;
        static private List<string> DescriptionsOrdered;

        public static void initializeEventList()
        {
            if (EventList is null)
            {
                EventList = new List<string>();
                EventList.AddRange(new List<string>
                {
                    "Virtual Coding Conference",
                    "Women in Coding",
                    "GlobalHack Intro to Coding Workshop"
                });
            }
        }

        public static void initializeEventDict()
        {
            if (EventDict is null)
            {
                EventDict = new Dictionary<string, string>();
                EventDict.Add("Virtual Coding Conference", 
                    "Helps prepare for coding in the new year");
                EventDict.Add("Women in Coding", "Discussion of History");
                EventDict.Add("GlobalHack Intro to Coding Workshop", "Learning resource for young people");
            }
        }

        public static List<string> updateDescriptionsOrdered()
        {
            DescriptionsOrdered = new List<string>();
            foreach(string evName in EventList)
            {
                DescriptionsOrdered.Add(EventDict[evName]);
            }
            return DescriptionsOrdered;
        }

        public IActionResult Index()
        {
            initializeEventList();
            initializeEventDict();
            ViewBag.events = EventList;
            ViewBag.descriptions = updateDescriptionsOrdered();
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(string eventName, string eventDescription)
        {
            initializeEventList();
            initializeEventDict();
            EventList.Add(eventName);
            EventDict.Add(eventName, eventDescription);

            return Redirect("/Events");
        }
    }
}

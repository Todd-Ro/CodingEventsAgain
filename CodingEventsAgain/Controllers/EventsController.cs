using CodingEventsAgain.Data;
using CodingEventsAgain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodingEventsAgain.Controllers
{
    public class EventsController : Controller
    {
        //static private List<string> EventList;
        //static private List<string> DescriptionsOrdered;
        //static private List<Event> EventObjList;

        

        /*public static void initializeEventList()
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

            
        }*/

        /*public static List<string> updateDescriptionsOrdered()
        {
            DescriptionsOrdered = new List<string>();
            foreach(string evName in EventList)
            {
                DescriptionsOrdered.Add(EventDict[evName]);
            }
            return DescriptionsOrdered;
        }*/

        public IActionResult Index()
        {
            //initializeEventList();
            EventData.InitializeEventDict();
            //ViewBag.events = EventList;
            //ViewBag.descriptions = updateDescriptionsOrdered();
            //ViewBag.eventObjects = EventObjList;
            ViewBag.eventObjects = EventData.GetAll();
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            EventData.InitializeEventDict();
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(
            //string name, string description
            Event newEvent
            )
        {
            //initializeEventList();
            EventData.InitializeEventDict();
            //EventList.Add(eventName);
            //EventDict.Add(eventName, eventDescription);
            //EventObjList.Add(new Event(eventName, eventDescription));
            //EventData.Add(new Event(eventName, eventDescription));
            EventData.Add(newEvent);

            return Redirect("/Events");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            ViewBag.eventObjects = EventData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }

        //Method to display edit form
        [HttpGet]
        [Route("/Events/Edit/{eventId?}")]
        public IActionResult Edit(int eventId)
        {
            Event eventToEdit = EventData.GetById(eventId);
            ViewBag.eventToEdit = eventToEdit;
            ViewBag.passedTitle = $"Edit Event {eventToEdit.Name} (id={eventId})";

            return View();
        }

        //Method to process edit form
        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            Event eventToEdit = EventData.GetById(eventId);
            eventToEdit.Name = name;
            eventToEdit.Description = description;

            return Redirect("/Events");
        }



    }
}

using BristolApiZone.Data.Context;
using BristolApiZone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BristolApiZone.Web.Controllers
{
    using Domain;
    using System.Data.Entity;
    using System.Linq;

    public class ScheduleController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new DatabaseContext())
            {
                var items = context.ScheduleItems.OrderBy(x => x.Id).ToList();

                return View(items);
            }
           
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult NextJourney()
        {
            using (var context = new DatabaseContext())
            {
                var schedule = context.ScheduleItems.Include(x => x.Destination).Include(x => x.Origin).FirstOrDefault();

                var origin = new PlacePoint
                {
                    Lat = schedule.Origin.Latitude,
                    Lng = schedule.Origin.Longitude
                };

                var destination = new PlacePoint
                {
                    Lat = schedule.Destination.Latitude,
                    Lng = schedule.Destination.Longitude
                };

                var resposne = Directions.GetDepartureDirections(origin, destination, DateTime.Now);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Add(ScheduleItem scheduleItem)
        {
            scheduleItem.TimeType = Request.Form["timeType"] == null ? TimeType.Departure : TimeType.Arrival;
            scheduleItem.Origin = GetLocationFromForm("origin-input-lat", "origin-input-lng");
            scheduleItem.Destination = GetLocationFromForm("destination-input-lat", "destination-input-lng");
            scheduleItem.Days = GetDaysFromForm();

            using (var context = new DatabaseContext())
            {
                var schedule = new Schedule
                {
                    ScheduleItems = new[] { scheduleItem }
                };

                context.Schedules.Add(schedule);

                context.SaveChanges();
            }

            return View();
        }

        private Location GetLocationFromForm(string latField, string lngField)
        {
            return new Location
            {
                Latitude = double.Parse(Request.Form[latField]),
                Longitude = double.Parse(Request.Form[lngField])
            };
        }

        private List<DayOfWeek> GetDaysFromForm()
        {
            var days = new List<DayOfWeek>();

            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                var isSelected = !string.IsNullOrWhiteSpace(Request.Form[day.ToString().ToLower()]);

                if (isSelected) days.Add(day);
            }

            return days;
        }
    }
}
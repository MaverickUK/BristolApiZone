using BristolApiZone.Data.Context;
using BristolApiZone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BristolApiZone.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            using (var context = new DatabaseContext())
            {
                var schedule = new Schedule
                {
                    ScheduleItems = new List<ScheduleItem>
                    {
                        new ScheduleItem
                        {
                            Name = "Work Commute",
                            Days = new [] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
                            TimeType = TimeType.Arrival,
                            Time = new TimeSpan(9, 30, 0),
                            Origin = new Location
                            {
                                Latitude = 42.441008,
                                Longitude = -71.125086
                            },
                            Destination = new Location
                            {
                                Latitude = 51.454513,
                                Longitude = -2.587910
                            }
                        }
                    }
                };

                context.Schedules.Add(schedule);

                context.SaveChanges();
            };


            return new ContentResult() { Content = "added test data" };          
        }
    }
}
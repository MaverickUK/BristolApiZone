using BristolApiZone.Data.Context;
using BristolApiZone.Domain.Models;
using System;
using System.Web.Mvc;

namespace BristolApiZone.Web.Controllers
{
    public class ScheduleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Schedule schedule)
        {
            using (var context = new DatabaseContext())
            {
                context.Schedules.Add(schedule);

                context.SaveChangesAsync();
            }
           
            return View();
        }
    }
}
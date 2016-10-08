using BristolApiZone.Data.Context;
using BristolApiZone.Domain.Models;
using System;
using System.Web.Mvc;

namespace BristolApiZone.Web.Controllers
{
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
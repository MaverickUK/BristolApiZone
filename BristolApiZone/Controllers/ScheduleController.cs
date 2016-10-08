using BristolApiZone.Data.Context;
using BristolApiZone.Domain.Models;
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
        public ActionResult Index(Schedule schedule)
        {
            using (var context = new DatabaseContext())
            {

            }

            return View(schedule);
        }
    }
}
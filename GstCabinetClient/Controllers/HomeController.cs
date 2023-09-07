using GstCabinetClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Numerics;

namespace GstCabinetClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ApplicationContext db;
        public HomeController(ApplicationContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var disponibilites = db.Disponibilites.ToList();
            var doctors = db.Medcins.ToList();
            ViewBag.doctors = doctors;
            ViewBag.RendezVous = db.RendezVous.ToList();
            return View(disponibilites);
        }
        public IActionResult GetPartial(int medcinid=0,int num=1)
        {
            //num ==numero de semaine
            var disponibilites = db.Disponibilites.Where(d => d.MedcinID == medcinid).ToList();
            var doctors = db.Medcins.ToList();
            ViewBag.doctors = doctors;
            ViewBag.RendezVous = db.RendezVous.ToList();

            ViewBag.num = num;
            ViewBag.medcinid = medcinid;

            return PartialView("_PartialCalendar", disponibilites);
        }
    }
}
using GstCabinetClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace GstCabinetClient.Controllers
{
    public class PatientController : Controller
    {
        public ApplicationContext db;
        public PatientController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Add(Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(patient);
        }

    }
}

using GstCabinetClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace GstCabinetClient.Controllers
{
    public class AuthentificationController : Controller
    {
        public ApplicationContext db;
        public AuthentificationController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult Connect()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Connect(Patient patient)
        {
            var pt = db.Patients.FirstOrDefault(m => m.Email.Equals(patient.Email) && m.Password.Equals(patient.Password));
            if (pt != null)
            {
                HttpContext.Session.SetInt32("Id", pt.Id);
                HttpContext.Session.SetString("fullname", pt.Nom + " " + pt.Prenom);
                return RedirectToAction("List", "RendezVous");
            }
            return View(patient);
        }
    }
}

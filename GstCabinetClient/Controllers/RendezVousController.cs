using GstCabinetClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GstCabinetClient.Controllers
{
    public class RendezVousController : Controller
    {
        public ApplicationContext db;
        public RendezVousController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add(int Id, int uId)
        {
            HttpContext.Session.SetInt32("Idispo", Id);
            HttpContext.Session.SetInt32("Idmed", uId);
            return View();
        }
        [HttpPost]
        public IActionResult Add(Patient patient)
        {
            //si iil est pas inscrit
            int? idpati = HttpContext.Session.GetInt32("Id");
            if (idpati==null)
            {
                patient.Id = 0;
                db.Patients.Add(patient);
                db.SaveChanges();
                idpati = patient.Id;
            }
                int? idispo = HttpContext.Session.GetInt32("Idispo");
                int? medid = HttpContext.Session.GetInt32("Idmed");
                var dispo = db.Disponibilites.FirstOrDefault(d => d.Id == idispo);
                var nouveauRendezVous = new RendezVous
                {
                    Date = dispo.DateRendezvous,
                    Horraire = dispo.Horraire,
                    PatientID = idpati,
                    MedcinID = medid,


                };

                db.RendezVous.Add(nouveauRendezVous);
                db.SaveChanges();
                HttpContext.Session.Remove("Idispo");
                HttpContext.Session.Remove("Idmed");
                return RedirectToAction("Index", "Home");
            
        }
        public IActionResult List()
        {
            int? idpati = HttpContext.Session.GetInt32("Id");
            List<RendezVous> lists = new List<RendezVous>();
                if (idpati.HasValue)
                {
                     lists = db.RendezVous.Include(t => t.Medcin).ToList();
                }

            return View(lists);
        }
          
        }
    }




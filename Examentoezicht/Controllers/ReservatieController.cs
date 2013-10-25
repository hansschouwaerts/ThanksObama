using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Examentoezicht.Models;

namespace Examentoezicht.Controllers
{
    public class ReservatieController : Controller
    {
        private ExamenToezichtDbContext db = new ExamenToezichtDbContext();

        // GET: /Reservatie/
        public ActionResult Index()
        {
            var reservaties = db.Reservaties.Include(r => r.Lector).Include(r => r.Toezichtbeurt);
            
            return View(reservaties.ToList());
        }

        // GET: /Reservatie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservatie reservatie = db.Reservaties.Find(id);
            if (reservatie == null)
            {
                return HttpNotFound();
            }
            return View(reservatie);
        }

        // GET: /Reservatie/Create
        public ActionResult Create()
        {
            ViewBag.LectorId = new SelectList(db.Lectoren, "LectorId", "Name");
            ViewBag.ToezichtbeurtId = new SelectList(db.ExamenLijst, "ToezichtbeurtId", "Datum");
            return View();
        }

        // POST: /Reservatie/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reservatie reservatie)
        {
            if (ModelState.IsValid)
            {
                db.Reservaties.Add(reservatie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.LectorId = new SelectList(db.Lectoren, "LectorId", "Name", reservatie.LectorId);
            ViewBag.ToezichtbeurtId = new SelectList(db.ExamenLijst, "ToezichtbeurtId", "Datum", reservatie.ToezichtbeurtId);
            ViewBag.ToezichtbeurtStart = new SelectList(db.ExamenLijst, "StartTijd", "Start", reservatie.Toezichtbeurt.Start);
            ViewData["StartTijd"] = new SelectList(db.ExamenLijst, "StartTijd", "Start");
            return View(reservatie);
        }

        // GET: /Reservatie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservatie reservatie = db.Reservaties.Find(id);
            if (reservatie == null)
            {
                return HttpNotFound();
            }
            ViewBag.LectorId = new SelectList(db.Lectoren, "LectorId", "Name", reservatie.LectorId);
            ViewBag.ToezichtbeurtId = new SelectList(db.ExamenLijst, "ToezichtbeurtId", "Datum", reservatie.ToezichtbeurtId);
            return View(reservatie);
        }

        // POST: /Reservatie/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reservatie reservatie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservatie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LectorId = new SelectList(db.Lectoren, "LectorId", "Name", reservatie.LectorId);
            ViewBag.ToezichtbeurtId = new SelectList(db.ExamenLijst, "ToezichtbeurtId", "Datum", reservatie.ToezichtbeurtId);
            return View(reservatie);
        }

        // GET: /Reservatie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservatie reservatie = db.Reservaties.Find(id);
            if (reservatie == null)
            {
                return HttpNotFound();
            }
            return View(reservatie);
        }

        // POST: /Reservatie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservatie reservatie = db.Reservaties.Find(id);
            db.Reservaties.Remove(reservatie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

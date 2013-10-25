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
    public class ExamenToezichtController : Controller
    {
        private ExamenToezichtDbContext db = new ExamenToezichtDbContext();

        // GET: /ExamenToezicht/
        public ActionResult Index(string searchString)
        {
            var campus = from m in db.ExamenLijst
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                campus = campus.Where(s => s.Campus.Contains(searchString));
            }
            return View(campus);
        }

        // GET: /ExamenToezicht/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toezichtbeurt toezichtbeurt = db.ExamenLijst.Find(id);
            if (toezichtbeurt == null)
            {
                return HttpNotFound();
            }
            return View(toezichtbeurt);
        }

        // GET: /ExamenToezicht/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ExamenToezicht/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Toezichtbeurt toezichtbeurt)
        {
            if (ModelState.IsValid)
            {
                db.ExamenLijst.Add(toezichtbeurt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toezichtbeurt);
        }

        // GET: /ExamenToezicht/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toezichtbeurt toezichtbeurt = db.ExamenLijst.Find(id);
            if (toezichtbeurt == null)
            {
                return HttpNotFound();
            }
            return View(toezichtbeurt);
        }

        // POST: /ExamenToezicht/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Toezichtbeurt toezichtbeurt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toezichtbeurt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toezichtbeurt);
        }

        // GET: /ExamenToezicht/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toezichtbeurt toezichtbeurt = db.ExamenLijst.Find(id);
            if (toezichtbeurt == null)
            {
                return HttpNotFound();
            }
            return View(toezichtbeurt);
        }

        // POST: /ExamenToezicht/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Toezichtbeurt toezichtbeurt = db.ExamenLijst.Find(id);
            db.ExamenLijst.Remove(toezichtbeurt);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterLab.Models;

namespace VeterLab.Controllers
{
    public class RecepcionsController : Controller
    {
        private PARCIAL2Entities db = new PARCIAL2Entities();

        // GET: Recepcions
        public ActionResult Index()
        {
            var recepcions = db.Recepcions.Include(r => r.Int_Clientes).Include(r => r.Laboratorio);
            return View(recepcions.ToList());
        }

        // GET: Recepcions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recepcion recepcion = db.Recepcions.Find(id);
            if (recepcion == null)
            {
                return HttpNotFound();
            }
            return View(recepcion);
        }

        // GET: Recepcions/Create
        public ActionResult Create()
        {
            ViewBag.Rut = new SelectList(db.Int_Clientes, "Rut", "Rut");
            ViewBag.LabId = new SelectList(db.Laboratorios, "Id", "Nombre");
            return View();
        }

        // POST: Recepcions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rut,LabId,Folio,FechaRecepcion,FechaEntrega,Localidad,CantidadMuestras")] Recepcion recepcion)
        {
            if (ModelState.IsValid)
            {
                db.Recepcions.Add(recepcion);
                db.SaveChanges();
                return RedirectToAction("Index","Detalles");
            }

            ViewBag.Rut = new SelectList(db.Int_Clientes, "Rut", "Rut", recepcion.Rut);
            ViewBag.LabId = new SelectList(db.Laboratorios, "Id", "Nombre", recepcion.LabId);
            return View(recepcion);
        }

        // GET: Recepcions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recepcion recepcion = db.Recepcions.Find(id);
            if (recepcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Rut = new SelectList(db.Int_Clientes, "Rut", "Nombre", recepcion.Rut);
            ViewBag.LabId = new SelectList(db.Laboratorios, "Id", "Nombre", recepcion.LabId);
            return View(recepcion);
        }

        // POST: Recepcions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rut,LabId,Folio,FechaRecepcion,FechaEntrega,Localidad,CantidadMuestras")] Recepcion recepcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recepcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Rut = new SelectList(db.Int_Clientes, "Rut", "Nombre", recepcion.Rut);
            ViewBag.LabId = new SelectList(db.Laboratorios, "Id", "Nombre", recepcion.LabId);
            return View(recepcion);
        }

        // GET: Recepcions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recepcion recepcion = db.Recepcions.Find(id);
            if (recepcion == null)
            {
                return HttpNotFound();
            }
            return View(recepcion);
        }

        // POST: Recepcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recepcion recepcion = db.Recepcions.Find(id);
            db.Recepcions.Remove(recepcion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

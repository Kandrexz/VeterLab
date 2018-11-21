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
    public class Int_ClientesController : Controller
    {
        private PARCIAL2Entities db = new PARCIAL2Entities();

        // GET: Int_Clientes
        public ActionResult Index()
        {
            return View(db.Int_Clientes.ToList());
        }

        // GET: Int_Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Int_Clientes int_Clientes = db.Int_Clientes.Find(id);
            if (int_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(int_Clientes);
        }

        // GET: Int_Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Int_Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Rut,Nombre,Direccion,Giro,Fono")] Int_Clientes int_Clientes)
        {
            if (ModelState.IsValid)
            {
                db.Int_Clientes.Add(int_Clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(int_Clientes);
        }

        // GET: Int_Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Int_Clientes int_Clientes = db.Int_Clientes.Find(id);
            if (int_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(int_Clientes);
        }

        // POST: Int_Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Rut,Nombre,Direccion,Giro,Fono")] Int_Clientes int_Clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(int_Clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(int_Clientes);
        }

        // GET: Int_Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Int_Clientes int_Clientes = db.Int_Clientes.Find(id);
            if (int_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(int_Clientes);
        }

        // POST: Int_Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Int_Clientes int_Clientes = db.Int_Clientes.Find(id);
            db.Int_Clientes.Remove(int_Clientes);
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

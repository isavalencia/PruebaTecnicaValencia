using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppCuentaPT;

namespace WebAppCuentaPT.Controllers
{
    public class transaccionesController : Controller
    {
        private ptcuentabancoEntities3 db = new ptcuentabancoEntities3();

        // GET: transacciones
        public ActionResult Index()
        {
            var transacciones = db.transacciones.Include(t => t.tarjeta);
            return View(transacciones.ToList());
        }

        // GET: transacciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transaccione transaccione = db.transacciones.Find(id);
            if (transaccione == null)
            {
                return HttpNotFound();
            }
            return View(transaccione);
        }

        // GET: transacciones/Create
        public ActionResult Create()
        {
            ViewBag.id_tarjeta = new SelectList(db.tarjetas, "id_tarjeta", "num_tarjeta");
            return View();
        }

        public ActionResult CreatePago()
        {
            ViewBag.id_tarjeta = new SelectList(db.tarjetas, "id_tarjeta", "num_tarjeta");
            return View();
        }

        // POST: transacciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_transaccion,id_tarjeta,fecha_transaccion,descripcion,monto,tipo_transaccion,num_autorizacion")] transaccione transaccione)
        {
            if (ModelState.IsValid)
            {
                db.transacciones.Add(transaccione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tarjeta = new SelectList(db.tarjetas, "id_tarjeta", "num_tarjeta", transaccione.id_tarjeta);
            return View(transaccione);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePago([Bind(Include = "id_transaccion,id_tarjeta,fecha_transaccion,descripcion,monto,tipo_transaccion,num_autorizacion")] transaccione transaccione)
        {
            if (ModelState.IsValid)
            {
                db.transacciones.Add(transaccione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tarjeta = new SelectList(db.tarjetas, "id_tarjeta", "num_tarjeta", transaccione.id_tarjeta);
            return View(transaccione);
        }

        // GET: transacciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transaccione transaccione = db.transacciones.Find(id);
            if (transaccione == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_tarjeta = new SelectList(db.tarjetas, "id_tarjeta", "num_tarjeta", transaccione.id_tarjeta);
            return View(transaccione);
        }

        // POST: transacciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_transaccion,id_tarjeta,fecha_transaccion,descripcion,monto,tipo_transaccion,num_autorizacion")] transaccione transaccione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaccione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tarjeta = new SelectList(db.tarjetas, "id_tarjeta", "num_tarjeta", transaccione.id_tarjeta);
            return View(transaccione);
        }

        // GET: transacciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transaccione transaccione = db.transacciones.Find(id);
            if (transaccione == null)
            {
                return HttpNotFound();
            }
            return View(transaccione);
        }

        // POST: transacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            transaccione transaccione = db.transacciones.Find(id);
            db.transacciones.Remove(transaccione);
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

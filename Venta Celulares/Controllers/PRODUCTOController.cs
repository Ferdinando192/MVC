using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Venta_Celulares;

namespace Venta_Celulares.Controllers
{
    public class PRODUCTOController : Controller
    {
        private Tdoo_celularesEntities db = new Tdoo_celularesEntities();

        // GET: PRODUCTO
        public ActionResult Index()
        {
            var pRODUCTO = db.PRODUCTO.Include(p => p.CATEGORIA);
            return View(pRODUCTO.ToList());
        }

        // GET: PRODUCTO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // GET: PRODUCTO/Create
        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.CATEGORIA, "IdCategoria", "Nombre");
            return View();
        }

        // POST: PRODUCTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,IdCategoria,Precio")] PRODUCTO pRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTO.Add(pRODUCTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoria = new SelectList(db.CATEGORIA, "IdCategoria", "Nombre", pRODUCTO.IdCategoria);
            return View(pRODUCTO);
        }

        // GET: PRODUCTO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategoria = new SelectList(db.CATEGORIA, "IdCategoria", "Nombre", pRODUCTO.IdCategoria);
            return View(pRODUCTO);
        }

        // POST: PRODUCTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,IdCategoria,Precio")] PRODUCTO pRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoria = new SelectList(db.CATEGORIA, "IdCategoria", "Nombre", pRODUCTO.IdCategoria);
            return View(pRODUCTO);
        }

        // GET: PRODUCTO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // POST: PRODUCTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            db.PRODUCTO.Remove(pRODUCTO);
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

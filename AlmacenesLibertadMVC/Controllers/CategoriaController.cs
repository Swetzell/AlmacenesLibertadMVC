using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using AlmacenesLibertadMVC;
using PagedList;

namespace AlmacenesLibertadMVC.Controllers
{
    public class CategoriaController : Controller
    {
        private bdalmaceneslibertadEntities db = new bdalmaceneslibertadEntities();

        //GET -> se utiliza para rutas y consultas(obtener informacion)
        // GET: Categoria -> Mostrar Categoria
        //public ActionResult Index()
        //{
        //    return View(db.categoria.ToList());
        //}

        public ActionResult Index(int? page)
        {
            //tamaño de la paginacion
            int pageSize = 10;
            //si no se especifica en que pagina comenzamos inicia en la primera
            int pageNumber = page ?? 1;
            //ordenamos por codigo
            var categorias = db.categoria
                .Where(c => c.estcat == true).OrderBy(c => c.codcat);
            var pagedCategorias = categorias.ToPagedList(pageNumber, pageSize);
            return View(pagedCategorias);
        }

        // GET: Categoria/Details/5 -> Buscar Categoria
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoria categoria = db.categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categoria/Create ->Mostrar Registrar Categoria
        public ActionResult Create()
        {
            return View();
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoria categoria = db.categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoria categoria = db.categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        public ActionResult Enable(int? page)
        {
            //tamaño de la paginacion
            int pageSize = 10;
            //si no se especifica en que pagina comenzamos inicia en la primera
            int pageNumber = page ?? 1;
            //ordenamos por codigo
            var categorias = db.categoria.OrderBy(c => c.codcat);
            var pagedCategorias = categorias.ToPagedList(pageNumber, pageSize);
            return View(pagedCategorias);
        }

        //public ActionResult EnableConfirmed(int id)
        //{
        //    categoria categoria = db.categoria.Find(id);
        //    //db.categoria.Remove(categoria);
        //    if (categoria != null)
        //    {
        //        //cambiamos el estado
        //        categoria.estcat = true;
        //        //guardamos los cambios
        //        db.SaveChanges();
        //    }

        //    return RedirectToAction("Enable");
        //}

        //public ActionResult DisableConfirmed(int id)
        //{
        //    categoria categoria = db.categoria.Find(id);
        //    //db.categoria.Remove(categoria);
        //    if (categoria != null)
        //    {
        //        //cambiamos el estado
        //        categoria.estcat = false;
        //        //guardamos los cambios
        //        db.SaveChanges();
        //    }

        //    return RedirectToAction("Enable");
        //}

        [HttpGet]
        public JsonResult EnableConfirmed(int id)
        {
            categoria categoria = db.categoria.Find(id);
            //db.categoria.Remove(categoria);
            if (categoria != null)
            {
                //cambiamos el estado
                categoria.estcat = true;
                //guardamos los cambios
                db.SaveChanges();
                return Json(new { success = true, estado = "Habilitado", id = categoria.codcat }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, message = "Categoria no encontrada" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DisableConfirmed(int id)
        {
            categoria categoria = db.categoria.Find(id);
            //db.categoria.Remove(categoria);
            if (categoria != null)
            {
                //cambiamos el estado
                categoria.estcat = false;
                //guardamos los cambios
                db.SaveChanges();
                return Json(new { success = true, estado = "Deshabilitado", id = categoria.codcat }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, message = "Categoria no encontrada" }, JsonRequestBehavior.AllowGet);
        }

        //HttpPost -> Acciones
        // POST: Categoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codcat,nomcat,estcat")] categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.categoria.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codcat,nomcat,estcat")] categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            categoria categoria = db.categoria.Find(id);
            //db.categoria.Remove(categoria);
            if (categoria != null)
            {
                //cambiamos el estado
                categoria.estcat = false;
                //guardamos los cambios
                db.SaveChanges();
            }

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


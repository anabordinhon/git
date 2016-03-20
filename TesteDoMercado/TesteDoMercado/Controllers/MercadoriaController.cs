using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TesteDoMercado.Models
{
    public class MercadoriaController : Controller
    {
        private MercadoriaModelDBContext db = new MercadoriaModelDBContext();

        // GET: Mercadoria
        public async Task<ActionResult> Index()
        {
            return View(await db.MercadoriaModels.ToListAsync());
        }

        // GET: Mercadoria/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MercadoriaModel mercadoriaModel = await db.MercadoriaModels.FindAsync(id);
            if (mercadoriaModel == null)
            {
                return HttpNotFound();
            }
            return View(mercadoriaModel);
        }

        // GET: Mercadoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mercadoria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Tipo,Nome,Quantidade,Preco,TipoNegocio")] MercadoriaModel mercadoriaModel)
        {
            if (ModelState.IsValid)
            {
                db.MercadoriaModels.Add(mercadoriaModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mercadoriaModel);
        }

        // GET: Mercadoria/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MercadoriaModel mercadoriaModel = await db.MercadoriaModels.FindAsync(id);
            if (mercadoriaModel == null)
            {
                return HttpNotFound();
            }
            return View(mercadoriaModel);
        }

        // POST: Mercadoria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Tipo,Nome,Quantidade,Preco,TipoNegocio")] MercadoriaModel mercadoriaModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mercadoriaModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mercadoriaModel);
        }

        // GET: Mercadoria/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MercadoriaModel mercadoriaModel = await db.MercadoriaModels.FindAsync(id);
            if (mercadoriaModel == null)
            {
                return HttpNotFound();
            }
            return View(mercadoriaModel);
        }

        // POST: Mercadoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MercadoriaModel mercadoriaModel = await db.MercadoriaModels.FindAsync(id);
            db.MercadoriaModels.Remove(mercadoriaModel);
            await db.SaveChangesAsync();
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

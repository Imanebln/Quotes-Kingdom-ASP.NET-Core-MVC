using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using jokes3.Models;
using jokes3.Quotes;

namespace jokes3.Controllers
{
    public class QuotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Quotes
        public ActionResult Index()
        {
            return View(db.Quotes.ToList());
        }

        // GET: Quotes/ShowSearchForm
        public  ActionResult ShowSearchForm()
        {
            return View();
        }

        // GET: Quotes/ShowSearchResults
        public ActionResult ShowSearchResults(String SearchPhrase)
        {
            return View("Index", db.Quotes.Where(j => j.Name.Contains(SearchPhrase)).ToList());
        }

        // GET: Quotes/ShowCategory
        public ActionResult ShowCategory()
        {
            /*QuoteDAO quoteDAO = new QuoteDAO();
            return View("ShowCategory", quoteDAO.SelectCategory());*/
            return View(db.Quotes.ToList());
        }


        // GET: Quotes/ShowCategoryResults
        public ActionResult ShowCategoryResults(String category)
        {
            return View("Index", db.Quotes.Where(j => j.Category.Equals(category)).ToList());
        }

        // GET: Quotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // GET: Quotes/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Category")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                db.Quotes.Add(quote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quote);
        }

        // GET: Quotes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // POST: Quotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Category")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quote);
        }

        // GET: Quotes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // POST: Quotes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quote quote = db.Quotes.Find(id);
            db.Quotes.Remove(quote);
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

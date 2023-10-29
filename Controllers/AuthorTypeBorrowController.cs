using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using u21445045_HW03.Models;
using u21445045_HW03.Models.ViewModels;

namespace u21445045_HW03.Controllers
{
    public class AuthorTypeBorrowController : Controller
    {
        LibraryEntities db = new LibraryEntities();

        // GET: AuthorTypeeBorrow
        public async Task<ActionResult> Index()
        {
            var viewModell = new List<AuthorTypeBorrow>
            {
                new AuthorTypeBorrow
                {
                    Authors = await db.authors.ToListAsync(),
                    Types =  await db.types.ToListAsync(),
                    Borrows = await db.borrows.ToListAsync(),
                }

            };
            return View(viewModell);
            
        }

        // GET: authors
        public async Task<ActionResult> AuthorIndex()
        {
            return View(await db.authors.ToListAsync());
        }

        // GET: authors/Details/5
        public async Task<ActionResult> AuthorDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            authors authors = await db.authors.FindAsync(id);
            if (authors == null)
            {
                return HttpNotFound();
            }
            return View(authors);
        }

        // GET: authors/Create
        public ActionResult AuthorCreate()
        {
            return View();
        }

        // POST: authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "authorId,name,surname")] authors authors)
        {
            if (ModelState.IsValid)
            {
                db.authors.Add(authors);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(authors);
        }

        // GET: authors/Edit/5
        public async Task<ActionResult> AuthorEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            authors authors = await db.authors.FindAsync(id);
            if (authors == null)
            {
                return HttpNotFound();
            }
            return View(authors);
        }

        // POST: authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AuthorEdit([Bind(Include = "authorId,name,surname")] authors authors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authors).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(authors);
        }

        // GET: authors/Delete/5
        public async Task<ActionResult> AuthorDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            authors authors = await db.authors.FindAsync(id);
            if (authors == null)
            {
                return HttpNotFound();
            }
            return View(authors);
        }

        // POST: authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AuthorDeleteConfirmed(int id)
        {
            authors authors = await db.authors.FindAsync(id);
            db.authors.Remove(authors);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> TypeIndex()
        {
            return View(await db.types.ToListAsync());
        }

        // GET: types/Details/5
        public async Task<ActionResult> TypeDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            types types = await db.types.FindAsync(id);
            if (types == null)
            {
                return HttpNotFound();
            }
            return View(types);
        }

        // GET: types/Create
        public ActionResult TypeCreate()
        {
            return View();
        }

        // POST: types/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> TypeCreate([Bind(Include = "typeId,name")] types types)
        {
            if (ModelState.IsValid)
            {
                db.types.Add(types);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(types);
        }

        // GET: types/Edit/5
        public async Task<ActionResult> TypeEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            types types = await db.types.FindAsync(id);
            if (types == null)
            {
                return HttpNotFound();
            }
            return View(types);
        }

        // POST: types/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> TypeEdit([Bind(Include = "typeId,name")] types types)
        {
            if (ModelState.IsValid)
            {
                db.Entry(types).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(types);
        }

        // GET: types/Delete/5
        public async Task<ActionResult> TypeDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            types types = await db.types.FindAsync(id);
            if (types == null)
            {
                return HttpNotFound();
            }
            return View(types);
        }

        // POST: types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> TypeDeleteConfirmed(int id)
        {
            types types = await db.types.FindAsync(id);
            db.types.Remove(types);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: borrows
        public async Task<ActionResult> BorrowIndex()
        {
            var borrows = db.borrows.Include(b => b.books).Include(b => b.students);
            return View(await borrows.ToListAsync());
        }

        // GET: borrows/Details/5
        public async Task<ActionResult> BorrowDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            borrows borrows = await db.borrows.FindAsync(id);
            if (borrows == null)
            {
                return HttpNotFound();
            }
            return View(borrows);
        }

        // GET: borrows/Create
        public ActionResult BorrowCreate()
        {
            ViewBag.bookId = new SelectList(db.books, "bookId", "name");
            ViewBag.studentId = new SelectList(db.students, "studentId", "name");
            return View();
        }

        // POST: borrows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> BorrowCreate([Bind(Include = "borrowId,studentId,bookId,takenDate,broughtDate")] borrows borrows)
        {
            if (ModelState.IsValid)
            {
                db.borrows.Add(borrows);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.bookId = new SelectList(db.books, "bookId", "name", borrows.bookId);
            ViewBag.studentId = new SelectList(db.students, "studentId", "name", borrows.studentId);
            return View(borrows);
        }

        // GET: borrows/Edit/5
        public async Task<ActionResult> BorrowEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            borrows borrows = await db.borrows.FindAsync(id);
            if (borrows == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookId = new SelectList(db.books, "bookId", "name", borrows.bookId);
            ViewBag.studentId = new SelectList(db.students, "studentId", "name", borrows.studentId);
            return View(borrows);
        }

        // POST: borrows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> BorrowEdit([Bind(Include = "borrowId,studentId,bookId,takenDate,broughtDate")] borrows borrows)
        {
            if (ModelState.IsValid)
            {
                db.Entry(borrows).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.bookId = new SelectList(db.books, "bookId", "name", borrows.bookId);
            ViewBag.studentId = new SelectList(db.students, "studentId", "name", borrows.studentId);
            return View(borrows);
        }

        // GET: borrows/Delete/5
        public async Task<ActionResult> BorrowDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            borrows borrows = await db.borrows.FindAsync(id);
            if (borrows == null)
            {
                return HttpNotFound();
            }
            return View(borrows);
        }

        // POST: borrows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> BorrowDeleteConfirmed(int id)
        {
            borrows borrows = await db.borrows.FindAsync(id);
            db.borrows.Remove(borrows);
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
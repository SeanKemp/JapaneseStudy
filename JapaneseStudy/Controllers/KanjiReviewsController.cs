using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JapaneseStudy.Data;
using JapaneseStudy.Models;

namespace JapaneseStudy.Controllers
{
    public class KanjiReviewsController : Controller
    {
        private readonly JapaneseStudyContext _context;

        public KanjiReviewsController(JapaneseStudyContext context)
        {
            _context = context;
        }

        // GET: KanjiReviews
        public async Task<IActionResult> Index()
        {
            return View(await _context.KanjiReview.ToListAsync());
        }

        // GET: KanjiReviews/Details/5
        public async Task<IActionResult> Details(int? pId, int? kId)
        {
            if (pId == null || kId == null)
            {
                return NotFound();
            }

            var kanjiReview = await _context.KanjiReview
                .FirstOrDefaultAsync(m => (m.PersonID == pId && m.KanjiID == kId));
            if (kanjiReview == null)
            {
                return NotFound();
            }

            return View(kanjiReview);
        }

        // GET: KanjiReviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KanjiReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,KanjiID,ReviewType,ReviewNo,IsLeech")] KanjiReview kanjiReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kanjiReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kanjiReview);
        }

        // GET: KanjiReviews/Edit/5
        public async Task<IActionResult> Edit(int? pId, int? kId)
        {
            if (pId == null || kId == null)
            {
                return NotFound();
            }

            var kanjiReview = await _context.KanjiReview.FindAsync(pId, kId);
            if (kanjiReview == null)
            {
                return NotFound();
            }
            return View(kanjiReview);
        }

        // POST: KanjiReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int pId, int kId, [Bind("PersonID,KanjiID,ReviewType,ReviewNo,IsLeech")] KanjiReview kanjiReview)
        {
            if (pId != kanjiReview.PersonID || kId != kanjiReview.KanjiID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kanjiReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KanjiReviewExists(kanjiReview.PersonID, kanjiReview.KanjiID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kanjiReview);
        }

        // GET: KanjiReviews/Delete/5
        public async Task<IActionResult> Delete(int? pId, int? kId)
        {
            if (pId == null || kId == null)
            {
                return NotFound();
            }

            var kanjiReview = await _context.KanjiReview
                .FirstOrDefaultAsync(m => (m.PersonID == pId && m.KanjiID == kId));
            if (kanjiReview == null)
            {
                return NotFound();
            }

            return View(kanjiReview);
        }

        // POST: KanjiReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int pId, int kId)
        {
            var kanjiReview = await _context.KanjiReview.FindAsync(pId, kId);
            _context.KanjiReview.Remove(kanjiReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KanjiReviewExists(int pId, int kId)
        {
            return _context.KanjiReview.Any(e => (e.PersonID == pId && e.KanjiID == kId));
        }
    }
}

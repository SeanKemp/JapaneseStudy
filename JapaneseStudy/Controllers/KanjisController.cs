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
    public class KanjisController : Controller
    {
        private readonly JapaneseStudyContext _context;

        public KanjisController(JapaneseStudyContext context)
        {
            _context = context;
        }

        // GET: Kanjis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kanji.ToListAsync());
        }

        // GET: Kanjis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kanji = await _context.Kanji
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kanji == null)
            {
                return NotFound();
            }

            return View(kanji);
        }

        // GET: Kanjis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kanjis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,KanjiChar,Meanings,Story,Primative,IsOnlyPrimative")] Kanji kanji)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kanji);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kanji);
        }

        // GET: Kanjis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kanji = await _context.Kanji.FindAsync(id);
            if (kanji == null)
            {
                return NotFound();
            }
            return View(kanji);
        }

        // POST: Kanjis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,KanjiChar,Meanings,Story,Primative,IsOnlyPrimative")] Kanji kanji)
        {
            if (id != kanji.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kanji);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KanjiExists(kanji.ID))
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
            return View(kanji);
        }

        // GET: Kanjis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kanji = await _context.Kanji
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kanji == null)
            {
                return NotFound();
            }

            return View(kanji);
        }

        // POST: Kanjis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kanji = await _context.Kanji.FindAsync(id);
            _context.Kanji.Remove(kanji);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KanjiExists(int id)
        {
            return _context.Kanji.Any(e => e.ID == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eLearnEnglish_ASP.Data;
using eLearnEnglish_ASP.Models;

namespace eLearnEnglish_ASP.Controllers
{
    public class MusicController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MusicController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Music
        public async Task<IActionResult> Index()
        {
            return View(await _context.MusicModel.ToListAsync());
        }

        // GET: Music/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicModel = await _context.MusicModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicModel == null)
            {
                return NotFound();
            }

            return View(musicModel);
        }

        // GET: Music/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Music/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Description,Category,CoverImageUrl,MusicUrl")] MusicModel musicModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musicModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(musicModel);
        }

        // GET: Music/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicModel = await _context.MusicModel.FindAsync(id);
            if (musicModel == null)
            {
                return NotFound();
            }
            return View(musicModel);
        }

        // POST: Music/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Description,Category,CoverImageUrl,MusicUrl")] MusicModel musicModel)
        {
            if (id != musicModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musicModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicModelExists(musicModel.Id))
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
            return View(musicModel);
        }

        // GET: Music/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicModel = await _context.MusicModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicModel == null)
            {
                return NotFound();
            }

            return View(musicModel);
        }

        // POST: Music/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musicModel = await _context.MusicModel.FindAsync(id);
            _context.MusicModel.Remove(musicModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicModelExists(int id)
        {
            return _context.MusicModel.Any(e => e.Id == id);
        }
    }
}

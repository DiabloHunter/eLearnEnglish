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
    public class VideoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VideoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Video
        public async Task<IActionResult> Index()
        {
            return View(await _context.VideoModel.ToListAsync());
        }

        // GET: Video/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoModel = await _context.VideoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videoModel == null)
            {
                return NotFound();
            }

            return View(videoModel);
        }

        // GET: Video/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Video/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,CoverImageUrl,VideoUrl")] VideoModel videoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(videoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(videoModel);
        }

        // GET: Video/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoModel = await _context.VideoModel.FindAsync(id);
            if (videoModel == null)
            {
                return NotFound();
            }
            return View(videoModel);
        }

        // POST: Video/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,CoverImageUrl,VideoUrl")] VideoModel videoModel)
        {
            if (id != videoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoModelExists(videoModel.Id))
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
            return View(videoModel);
        }

        // GET: Video/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoModel = await _context.VideoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videoModel == null)
            {
                return NotFound();
            }

            return View(videoModel);
        }

        // POST: Video/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var videoModel = await _context.VideoModel.FindAsync(id);
            _context.VideoModel.Remove(videoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoModelExists(int id)
        {
            return _context.VideoModel.Any(e => e.Id == id);
        }
    }
}

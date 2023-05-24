using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLTB.Data;
//using QLTB.Test_models;
using QLTB.Models;


namespace QLTB.Controllers
{
    public class QltbController : Controller
    {
        private readonly QltbContext _context;
        public QltbController(QltbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var devices = from d in _context.Thietbi.Include(s => s.Loaithietbi)
                          .Include(s => s.Donvi)
                          select d;
            var Thietbis = await devices.ToListAsync();
            var devicesVM = new DevicesViewModel
            {
                Thietbis = Thietbis
            };
            return View(devicesVM);
        }

        public async Task<IActionResult> Create()
        {
            var Donvis = await _context.Donvi.ToListAsync();
            var Loaithietbis = await _context.Loaithietbi.ToListAsync();
            var donviLoaitbVM = new DonviLoaithietbiViewModel
            {
                Loaithietbis = Loaithietbis,
                Donvis = Donvis
            };
            ViewData["DonviLoaithietbiVM"] = donviLoaitbVM;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Madv", "Maloai", "Tentb", "Nuocsx")] Thietbi thietbi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thietbi);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(thietbi);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var thietbi = await _context.Thietbi.FirstOrDefaultAsync(m => m.Matb == id);
            if (thietbi == null)
            {
                return NotFound();
            }
            var Donvis = await _context.Donvi.ToListAsync();
            var Loaithietbis = await _context.Loaithietbi.ToListAsync();
            var donviLoaitbVM = new DonviLoaithietbiViewModel
            {
                Loaithietbis = Loaithietbis,
                Donvis = Donvis
            };
            ViewData["DonviLoaithietbiVM"] = donviLoaitbVM;
            return View(thietbi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string Tentb, string Nuocsx)
        {
            if (id == null)
            {
                return NotFound();
            }
            var thietbiToUpdate = await _context.Thietbi.FirstOrDefaultAsync(m => m.Matb == id);
            if (await TryUpdateModelAsync<Thietbi>(thietbiToUpdate, "", m => m.Madv, m => m.Maloai,
                m => m.Tentb, m => m.Nuocsx))
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thietbiToUpdate);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thietbi = await _context.Thietbi.Include(i => i.Donvi).Include(i => i.Loaithietbi)
                .FirstOrDefaultAsync(m => m.Matb == id);
            if (thietbi == null)
            {
                return NotFound();
            }

            return View(thietbi);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Thietbi thietbi = await _context.Thietbi.SingleAsync(m => m.Matb == id);
            _context.Thietbi.Remove(thietbi);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}

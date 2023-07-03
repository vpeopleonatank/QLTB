using Microsoft.AspNetCore.Mvc;
using HD.Station.Qltb.Abstractions.Data;
using HD.Station.Qltb.Abstractions.Abstractions;
using HD.Station.Qltb.Mvc.Models;

namespace HD.Station.Qltb.Mvc.Controllers
{
    [Area("Qltb")]
    public class QltbController : Controller
    {
        private readonly IDeviceManagement _deviceManage;
        public QltbController(IDeviceManagement deviceManagement)
        {
            _deviceManage = deviceManagement;
        }
        public async Task<IActionResult> Index()
        {
            var devices = await _deviceManage.GetAllDevices();
            var devicesVM = new DevicesViewModel
            {
                Thietbis = devices as List<Thietbi>
            };
            return View(devicesVM);
        }

        public async Task<IActionResult> Create()
        {
            var Donvis = await _deviceManage.GetAllDonvi();
            var Loaithietbis = await _deviceManage.GetAllLoaithietbi();
            var donviLoaitbVM = new DonviLoaithietbiViewModel
            {
                Loaithietbis = Loaithietbis as ICollection<Loaithietbi>,
                Donvis = Donvis as ICollection<Donvi>
            };
            ViewData["DonviLoaithietbiVM"] = donviLoaitbVM;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Madv", "Maloai", "Tentb", "Nuocsx")] Thietbi thietbi)
        {
            if (ModelState.IsValid)
            {
                _deviceManage.Add(thietbi);
                return RedirectToAction("Index");
            }
            return View(thietbi);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var thietbi = await _deviceManage.GetDeviceById((long)id);
            if (thietbi == null)
            {
                return NotFound();
            }
            var Donvis = await _deviceManage.GetAllDonvi();
            var Loaithietbis = await _deviceManage.GetAllLoaithietbi();
            var donviLoaitbVM = new DonviLoaithietbiViewModel
            {
                Loaithietbis = Loaithietbis as ICollection<Loaithietbi>,
                Donvis = Donvis as ICollection<Donvi>            };
            ViewData["DonviLoaithietbiVM"] = donviLoaitbVM;
            return View(thietbi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Madv", "Maloai", "Tentb", "Nuocsx")] Thietbi thietbi)
        {
            if (thietbi == null)
            {
                return NotFound();
            }
            await _deviceManage.Update(thietbi);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thietbi = await _deviceManage.GetDeviceById(id);
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
            await _deviceManage.Remove(id);

            return RedirectToAction(nameof(Index));
        }

    }
}

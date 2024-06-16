using Microsoft.AspNetCore.Mvc;
using TallerAPI.Models;
using TallerAPI.Services;

namespace TallerAPI.Controllers
{
    public class AutosController : Controller
    {
        private readonly AutoService _autoService;
        public AutosController(AutoService autoService) =>
            _autoService = autoService;

        

        public IActionResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Automovil automovil)
        {
            if (automovil == null)
            {
                return View(automovil);
            }
            await _autoService.CreateAsync(automovil);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string id)
        {
            var automovil = await _autoService.GetAsync(id);
            if (automovil is null)
            {
                return NotFound();
            }
            return View(automovil);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Automovil automovil) {
            if (!ModelState.IsValid)
            {
                return View(automovil);
            }
            await _autoService.UpdateAsync(id, automovil);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(String id)
        {
            var automovil = await _autoService.GetAsync(id);
            if (automovil == null)
            {
                return NotFound();
            }
            return View(automovil);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _autoService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Index(string searchId)
        {
            IEnumerable<Automovil> automoviles;
            if (!String.IsNullOrEmpty(searchId))
            {
                var automovil = await _autoService.GetAsync(searchId);
                automoviles = automovil != null ? new List<Automovil> { automovil } : new List<Automovil>();
            }
            else
            {
                automoviles = await _autoService.GetAsync();
            }

            return View(automoviles);
        }

        public async Task<IActionResult> Details(string id)
        {
            var automovil = await _autoService.GetAsync(id);
            if (automovil == null)
            {
                return NotFound();
            }
            return View(automovil);
        }
    }



}


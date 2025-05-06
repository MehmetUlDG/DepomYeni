using System.Threading.Tasks;
using efCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace efCoreApp.Controllers
{
    public class MusteriController : Controller
    {
        private readonly DataContext _context;
        public MusteriController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var musteriler = _context.Musteriler.ToList();
            return View(musteriler);

        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Musteri model)
        {
            if (ModelState.IsValid)
            {
                _context.Musteriler.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musteri = await _context.Musteriler.Include(m => m.Siparisler).ThenInclude(s => s.Urun).FirstOrDefaultAsync(m => m.MusteriId == id);

            if (musteri == null)
            {
                return NotFound();
            }

            return View(musteri);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Musteri model, int? id)
        {
            if (id != model.MusteriId)
            {
                return NotFound();
            }
            else if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!_context.Musteriler.Any(m => m.MusteriId == model.MusteriId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var musteri = await _context.Musteriler.FindAsync(id);
            if (musteri == null)
            {
                return NotFound();
            }
            return View(musteri);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Musteri model)
        {
            var musteri = await _context.Musteriler.FindAsync(model.MusteriId);
            if (musteri == null)
            {
                return NotFound();
            }
            try
            {
                _context.Musteriler.Remove(musteri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Musteriler.Any(m => m.MusteriId == model.MusteriId))
                {
                    return
                    NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
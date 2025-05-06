using efCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace efCoreApp.Controllers
{
    public class UrunController : Controller
    {
        private readonly DataContext _context;
        public UrunController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var urunler = _context.Urunler.ToList();
            return View(urunler);

        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Urun model)
        {
            if (ModelState.IsValid)
            {
                model.UrunBarkod = Guid.NewGuid();
                _context.Urunler.Add(model);
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

            var musteri = await _context.Urunler.Include(m => m.Siparisler).ThenInclude(m => m.Musteri).FirstOrDefaultAsync(m => m.UrunId == id);

            if (musteri == null)
            {
                return NotFound();
            }

            return View(musteri);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Urun model, int? id)
        {
            if (id != model.UrunId)
            {
                return NotFound();
            }
            else if (ModelState.IsValid)
            {
                try
                {
                    var mevcutUrun = await _context.Urunler.FindAsync(model.UrunId);

                    if (mevcutUrun == null)
                    {
                        return NotFound();
                    }

                    mevcutUrun.Ad = model.Ad;
                    mevcutUrun.Kategori = model.Kategori;
                    mevcutUrun.Fiyat = model.Fiyat;
                    mevcutUrun.StokMiktarı = model.StokMiktarı;
                    mevcutUrun.Açıklama = model.Açıklama;

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!_context.Urunler.Any(m => m.UrunId == model.UrunId))
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
            var urun = await _context.Urunler.FindAsync(id);
            if (urun == null)
            {
                return NotFound();
            }
            return View(urun);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Urun model)
        {
            var urun = await _context.Urunler.FindAsync(model.UrunId);
            if (urun == null)
            {
                return NotFound();
            }
            try
            {
                _context.Urunler.Remove(urun);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Urunler.Any(m => m.UrunId == model.UrunId))
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
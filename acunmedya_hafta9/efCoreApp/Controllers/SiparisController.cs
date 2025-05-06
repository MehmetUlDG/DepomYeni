using efCoreApp.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace efCoreApp.Controllers
{

    public class SiparisController : Controller
    {
        private readonly DataContext _context;

        public SiparisController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var siparisler = await _context.Siparisler.Include(x => x.Urun).Include(x => x.Musteri).ToListAsync();
            return View(siparisler);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Urunler = new SelectList(await _context.Urunler.ToListAsync(), "UrunId", "UrunAd");
            ViewBag.Musteriler = new SelectList(await _context.Musteriler.ToListAsync(), "Id", "AdSoyad");

            return View();
        }
        [HttpPost]

        [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var siparisler = await _context.Siparisler.FirstOrDefaultAsync(siparisler => siparisler.SiparisId == Id);
            if (siparisler == null)
            {
                return NotFound();
            }
            return View(siparisler);

        }
        [HttpPost]
        public async Task<IActionResult> Create(Siparis siparis)
        {
            try
            {
                // 1. İlişkili nesneleri yükle
                var musteri = await _context.Musteriler
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.Id == siparis.MusteriId);

                var urun = await _context.Urunler
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.UrunId == siparis.UrunId);

                if (musteri == null || urun == null)
                {
                    ModelState.AddModelError("", "Müşteri veya ürün bulunamadı");
                    await LoadViewBags();
                    return View(siparis);
                }

                // 2. Yeni sipariş oluştur
                var yeniSiparis = new Siparis
                {
                    MusteriId = musteri.Id,
                    UrunId = urun.UrunId,
                    SiparisTarihi = DateTime.Now,
                    Durum = "Yeni",
                    ToplamTutar = urun.Fiyat,
                    Urun = null, // İlişkiyi kesiyoruz
                    Musteri = null // İlişkiyi kesiyoruz
                };

                // 3. State'i manuel ayarla
                _context.Entry(yeniSiparis).State = EntityState.Added;

                // 4. Değişiklikleri kontrol et
                Console.WriteLine(_context.ChangeTracker.DebugView.LongView);

                // 5. Kaydet
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: {ex.ToString()}");
                ModelState.AddModelError("", $"Kayıt hatası: {ex.Message}");
                await LoadViewBags();
                return View(siparis);
            }
        }

        private async Task LoadViewBags()
        {
            ViewBag.Urunler = new SelectList(await _context.Urunler.ToListAsync(), "UrunId", "UrunAd");
            ViewBag.Musteriler = new SelectList(await _context.Musteriler.ToListAsync(), "Id", "AdSoyad");
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var siparisler = await _context.Siparisler.FindAsync(Id);
            if (siparisler == null)
            {
                return NotFound();
            }

            try
            {
                _context.Siparisler.Remove(siparisler);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                return BadRequest($"Silme sırasında hata oluştu: {ex.Message}");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var siparisler = await _context.Siparisler.FirstOrDefaultAsync(siparisler => siparisler.SiparisId == Id);
            if (siparisler == null)
            {
                return NotFound();
            }
            return View(siparisler);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? Id, Siparis model)
        {
            if (Id != model.SiparisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Siparisler.Any(m => m.MusteriId == model.SiparisId))
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


            return View(model);
        }

    }
}
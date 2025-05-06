using Microsoft.AspNetCore.Mvc;
using efCoreApp.Data;
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
    public IActionResult Index()
    {

      var siparisler = _context.Siparisler.Include(x => x.Musteri).Include(x => x.Urun).ToList();
      return View(siparisler);
    }

    [HttpGet]
    public IActionResult Create()
    {
      ViewBag.Musteriler = new SelectList(_context.Musteriler.ToList(), "MusteriId", "AdSoyad");
      ViewBag.Urunler = new SelectList(_context.Urunler.ToList(), "UrunId", "Ad");
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Siparis model)
    {
      if (ModelState.IsValid)
      {
        model.SiparisTarihi = DateTime.Now;
        model.Durum = "Yeni";
        model.ToplamTutar = 0;
        _context.Siparisler.Add(model);
        await _context.SaveChangesAsync();
        ViewBag.Musteriler = new SelectList(_context.Musteriler.ToList(), "MusteriId", "AdSoyad");
        ViewBag.Urunler = new SelectList(_context.Urunler.ToList(), "UrunId", "Ad");
        return RedirectToAction(nameof(Index));
      }
      return View(model);
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
      var siparis = await _context.Siparisler.FindAsync(id);
      if (siparis == null)
      {
        return NotFound();
      }
      ViewBag.Musteriler = new SelectList(_context.Musteriler.ToList(), "MusteriId", "AdSoyad", siparis.MusteriId);
      ViewBag.Urunler = new SelectList(_context.Urunler.ToList(), "UrunId", "Ad", siparis.UrunId);
      return View(siparis);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Siparis model, int id)
    {

      if (ModelState.IsValid)
      {
        var siparis = await _context.Siparisler.FindAsync(id);
        if (siparis == null)
        {
          return NotFound();
        }
        try
        {

          siparis.MusteriId = model.MusteriId;
          siparis.UrunId = model.UrunId;
          siparis.Durum = model.Durum;
          siparis.SiparisTarihi = model.SiparisTarihi ?? DateTime.Now;

          _context.Siparisler.Update(siparis);
          await _context.SaveChangesAsync();
          return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateConcurrencyException ex)
        {
          ModelState.AddModelError("", "Güncelleme sırasında hata oluştu: " + ex.Message);
        }
      }
      ViewBag.Musteriler = new SelectList(_context.Musteriler.ToList(), "MusteriId", "AdSoyad", model.MusteriId);
      ViewBag.Urunler = new SelectList(_context.Urunler.ToList(), "UrunId", "Ad", model.UrunId);
      return View(model);
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
      var siparis = await _context.Siparisler.FindAsync(id);
      if (siparis == null)
      {
        return NotFound();
      }
      ViewBag.Musteriler = new SelectList(_context.Musteriler.ToList(), "MusteriId", "AdSoyad", siparis.MusteriId);
      ViewBag.Urunler = new SelectList(_context.Urunler.ToList(), "UrunId", "Ad", siparis.UrunId);
      return View(siparis);
    }
    [HttpPost]
    public async Task<IActionResult> Delete(Siparis model, int id)
    {
      if (ModelState.IsValid)
      {
        var siparis = await _context.Siparisler.FindAsync(id);
        if (siparis == null)
        {
          return NotFound();
        }
        try
        {
          _context.Siparisler.Remove(siparis);
          await _context.SaveChangesAsync();
          return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateConcurrencyException ex)
        {
          ModelState.AddModelError("", "Silme sırasında hata oluştu: " + ex.Message);
        }
      }
      ViewBag.Musteriler = new SelectList(_context.Musteriler.ToList(), "MusteriId", "AdSoyad", model.MusteriId);
      ViewBag.Urunler = new SelectList(_context.Urunler.ToList(), "UrunId", "Ad", model.UrunId);
      return View(model);
    }
  }
}
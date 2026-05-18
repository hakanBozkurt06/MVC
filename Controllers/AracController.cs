using Microsoft.AspNetCore.Mvc;
using VehicleGallery.Models;
using VehicleGallery.Models.ViewModels;

namespace VehicleGallery.Controllers
{
    public class AracController : Controller
    {
        public IActionResult Index()
        {
            List<Arac> list = null;
            using (var ctx = new GaleriDbContext())
            {
                list = ctx.Araclar.ToList();
            }
            return View(list);
        }

        

        //[HttpPost]
        //public ViewResult AracEkle(IFormCollection fc)
        //{
        //    var arac = new Arac();
        //    arac.Marka = fc["txtMarka"].ToString();
        //    arac.Model = fc["txtModel"].ToString();
        //    arac.Yil = int.Parse(fc["txtYil"].ToString());
        //    using (var ctx = new GaleriDbContext())
        //    {
        //        ctx.Araclar.Add(arac);
        //        ctx.SaveChanges();
        //    }
        //    return View();
        //}

        [HttpPost]
        public IActionResult AracEkle(Arac arac)
        {
            if (!ModelState.IsValid)
            {
                return View(arac);
            }
            using (var ctx = new GaleriDbContext())
            {
                ctx.Araclar.Add(arac);
                ctx.SaveChanges();
            }
            TempData["Mesaj"] = "Araç başarıyla eklendi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult AracEkle()
        {
            return View();
        }

        [HttpGet]
        public ViewResult AracDuzenle(int id)
        {
            Arac arac = null;
            using (var ctx = new GaleriDbContext())
            {
                arac = ctx.Araclar.Find(id);
            }
            return View(arac);
        }

        [HttpPost]
        public IActionResult AracDuzenle(Arac arac)
        {
            if (!ModelState.IsValid)
            {
                return View(arac);
            }
            using (var ctx = new GaleriDbContext())
            {
                ctx.Araclar.Update(arac);
                ctx.SaveChanges();
            }
            TempData["Mesaj"] = "Araç başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        public IActionResult AracSil(int id)
        {
            using (var ctx = new GaleriDbContext())
            {
                var arac = ctx.Araclar.Find(id);
                ctx.Araclar.Remove(arac);
                ctx.SaveChanges();
            }
            TempData["Mesaj"] = "Araç başarıyla silindi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult AracBilgi(int id)
        {
            Arac arac = null;
            using (var ctx = new GaleriDbContext())
            {
                arac = ctx.Araclar.Find(id);
            }
            return View(arac);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Devam.Models;
using System.Data.Entity;


namespace MVC_Devam.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        public ActionResult Index()
        {
            using (KirazBilisimContext context=new KirazBilisimContext())
            {
                var urunler = context.Urunler.Include(x=>x.Kategori).ToList(); //çektıgımız tabloda baska tabloya aıt bır sutun varsa bunun ıcın ınclude kullanmamız lazım yanı urunlerı cekerken herbır urunun kategorisini cek yani joınleme yapmıs gıbı oluyor.
                return View(urunler);
            }            
        }

        [HttpGet]
        public ActionResult Kaydet(int id)
        {
            using (var context=new KirazBilisimContext())
            {
                ViewBag.Kategoriler = context.Kategoriler.Select(x=> new SelectListItem
                {
                    Text = x.KategoriAd, //kategorileri combobox a getırmek ıcın bunu yaptıkk
                    Value = x.Id.ToString()
                }).ToList();

                var urun = context.Urunler.Find(id);
                return View(urun);
            }
        }

        [HttpPost]
        public ActionResult Kaydet(Urun model)
        {
            //Urun model=new Urun();
            //UpdateModel(model); //view den gelen nesneme gore dolduruyor. 
            //mesela telerıkte run ettıgımızde ordan degıstırmeyı engellemek ıcın fonksiyona parametre vermek yerıne update model yapmak daha mantıklıdır.
            using (var context=new KirazBilisimContext())
            {
                Urun urun;
                if (model.Id > 0)
                {
                    urun = context.Urunler.Find(model.Id);
                }
                else
                {
                    urun=new Urun();
                    context.Urunler.Add(urun);
                }
                urun.Ad = model.Ad;
                urun.Fiyat = model.Fiyat;
                urun.Stok = model.Stok;
                urun.KategoriId = model.KategoriId;
                context.SaveChanges();
            }           
            return RedirectToAction("Index");
        }
    }
}
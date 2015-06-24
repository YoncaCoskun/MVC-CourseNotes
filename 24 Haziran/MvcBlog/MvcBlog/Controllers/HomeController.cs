using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;
using MvcBlog.EF;
using MvcBlog.Entities;
using MvcBlog.Models;
using System.Data.Entity;

namespace MvcBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using ( BlogContext context = new BlogContext())
            {
                var makaleler= context.Makaleler.Select(x => new ViewModelMakale
                {
                    Baslik = x.Baslik,
                    Ozet = x.Ozet,
                    Id = x.Id,
                    KategoriId = x.KategoriId,
                    Dislike = x.Dislike,
                    Like = x.Like,
                    KategoriAd = x.Kategori.Ad,
                    OkunmaSayisi = x.OkunmaSayisi,
                    Tarih = x.EklenmeTarihi

                }).ToList();

                return View(makaleler);
            }
           
       
        }

        public ActionResult _KategoriPartial()
        {
            using (BlogContext context=new BlogContext())
            {
               var kategoriler=context.Kategoriler.Select(x => new ViewModelKategori
                {
                    Id=x.Id,
                    Ad = x.Ad
                }).ToList();

                return PartialView(kategoriler);
            }
        }

        public ActionResult Detay(int id)
        {
            using (BlogContext context=new BlogContext())
            {
                ViewModelMakale mdl=new ViewModelMakale();
              var makale=  context.Makaleler.Find(id);

                mdl.Id = makale.Id;
                mdl.Baslik = makale.Baslik;
                mdl.OkunmaSayisi = ++makale.OkunmaSayisi;
                mdl.Icerik = makale.Icerik;
                mdl.Tarih = makale.EklenmeTarihi;
                mdl.Like = makale.Like;
                mdl.Dislike = makale.Dislike;
                mdl.KategoriAd = makale.Kategori.Ad;

                context.SaveChanges();
                
                return View(mdl);
            }
        }

        public JsonResult YorumYaz(ViewModelYorum mdl)
        {
            using (BlogContext context=new BlogContext())
            {
               var yeniYorum=new Yorum();
                yeniYorum.Icerik = mdl.Icerik.Trim();
                yeniYorum.MakaleId = mdl.MakaleId;
                yeniYorum.Yazan = mdl.Yazan;

                context.Yorumlar.Add(yeniYorum);
                context.SaveChanges();
                return Json("ok");



            }
        }
    }
}
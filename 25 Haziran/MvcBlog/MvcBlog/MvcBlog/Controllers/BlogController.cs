using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBlog.EF;
using MvcBlog.Models;

namespace MvcBlog.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Blog/
        public ActionResult Index()
        {
            using (MvcBlogContext context = new MvcBlogContext())
            {
                List<ViewModelMakale> makaleler = context.Makaleler.Where(x => x.Silindi == false).Select(x => new ViewModelMakale
                {
                    Id = x.Id,
                    Baslik = x.Baslik,
                    KategoriAd = x.Kategori.Ad,
                    OkunmaSayisi = x.OkunmaSayisi,
                    Ozet = x.Ozet,
                    Tarih = x.YazilmaTarihi
                }).OrderByDescending(x => x.Id).ToList();

                return View(makaleler);
            }
        }

        public ActionResult _KategoriPartial()
        {
            using (MvcBlogContext db=new MvcBlogContext())
            {
                List<ViewModelKategori> kategoriler = db.Kategoriler.Select(x => new ViewModelKategori
                {
                    Id = x.Id,
                    Ad = x.Ad
                }).ToList();
                return PartialView(kategoriler);
            }
        }





    }
}
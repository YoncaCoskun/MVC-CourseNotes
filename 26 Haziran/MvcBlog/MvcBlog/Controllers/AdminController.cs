using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBlog.Attributes;
using MvcBlog.EF;
using MvcBlog.Entities;
using MvcBlog.Models;

namespace MvcBlog.Controllers
{
    [LoginGerektirir]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MakaleListele()
        {
            using (BlogContext context = new BlogContext())
            {
                var makaleler = context.Makaleler.Select(x => new ViewModelMakale
                {
                    Baslik = x.Baslik,
                    Id = x.Id,
                    KategoriId = x.KategoriId,
                    Dislike = x.Dislike,
                    Like = x.Like,
                    KategoriAd = x.Kategori.Ad,
                    OkunmaSayisi = x.OkunmaSayisi,
                    Tarih = x.EklenmeTarihi,
                    Pasif = x.Pasif
                })
             .OrderByDescending(x => x.Id)
             .ToList();

                return View(makaleler);
            }
        }

        public ActionResult MakaleKaydet(int id)
        {
            using (BlogContext context = new BlogContext())
            {
                var makale = context.Makaleler.Find(id);

                ViewModelMakale mdl = new ViewModelMakale();

                if (makale != null)
                {
                    mdl = new ViewModelMakale
                    {
                        Id = makale.Id,
                        Baslik = makale.Baslik,
                        Dislike = makale.Dislike,
                        Icerik = makale.Icerik,
                        KategoriAd = makale.Kategori.Ad,
                        KategoriId = makale.KategoriId,
                        Like = makale.Like,
                        OkunmaSayisi = makale.OkunmaSayisi,
                        Ozet = makale.Ozet,
                        Tarih = makale.EklenmeTarihi
                    };


                    mdl.Etiketler = context.MakaleEtiketler
                                                            .Where(x => x.MakaleId == id)
                                                            .Select(x => new ViewModelMakaleEtiket
                                                              {
                                                                  EtiketAd = x.Etiket.Ad,
                                                                  EtiketId = x.EtiketId,
                                                                  MakaleId = x.MakaleId
                                                              }).ToList();

                }

                mdl.KategorilerTum = context.Kategoriler.Select(x => new SelectListItem
                {
                    Text = x.Ad,
                    Value = x.Id.ToString()
                }).ToList();

                return View(mdl);
            }
        }

        [HttpPost]
        public ActionResult MakaleKaydet(ViewModelMakale mdl)
        {
            using (BlogContext context = new BlogContext())
            {
                Makale mkl;
                if (mdl.Id > 0)
                {
                    mkl = context.Makaleler.Find(mdl.Id);
                }
                else
                {
                    mkl = new Makale();
                    context.Makaleler.Add(mkl);
                }

                mkl.Baslik = mdl.Baslik.Trim();
                mkl.Icerik = mdl.Icerik;
                mkl.KategoriId = mdl.KategoriId;
                mkl.Ozet = mdl.Ozet;

                context.SaveChanges();
            }
            return RedirectToAction("MakaleListele");
        }

        public JsonResult YayinDurumDegistir(int id)
        {
            using (BlogContext context = new BlogContext())
            {
                var makale = context.Makaleler.Find(id);

                makale.Pasif = !makale.Pasif;

                context.SaveChanges();

                return Json(makale.Pasif);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBlog.EF;
using MvcBlog.Models;

namespace MvcBlog.Controllers
{
   
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            MvcBlogContext context = new MvcBlogContext();
            var yrm = context.Yorumlar.ToList();
            return View();
        }

        public ActionResult Giris()
        {
            return View();
        }

        public ActionResult GirisYap(string kullaniciAdi, string parola)
        {
            using (MvcBlogContext context = new MvcBlogContext())
            {
                Kullanici user = context.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == kullaniciAdi.Trim() && x.Parola == parola.Trim());
                if (user == null)
                {
                    ViewBag.GirisMesaji = "Kullanıcı adı ya da parola hatalıdır.";
                    return View("Giris");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }

        #region MakaleIslemleri

        public ActionResult MakaleListele()
        {
            using (MvcBlogContext context = new MvcBlogContext())
            {
                List<ViewModelMakaleAdmin> makaleler = context.Makaleler.Select(x => new ViewModelMakaleAdmin
                {
                    Id = x.Id,
                    Baslik = x.Baslik,
                    Tarih = x.YazilmaTarihi,
                    OkunmaSayisi = x.OkunmaSayisi,
                    Silindi = x.Silindi
                }).OrderByDescending(x => x.Tarih).ToList();

                return View(makaleler);
            }
        }

        [HttpGet]
        public ActionResult MakaleEkle(int id)
        {
            using (MvcBlogContext context = new MvcBlogContext())
            {
                Makale makale = context.Makaleler.Find(id);

                ViewModelMakale mdl = new ViewModelMakale();

                mdl.KategoriListesi = context.Kategoriler.Select(
                                                                                                        x => new SelectListItem
                                                                                                        {
                                                                                                            Text = x.Ad,
                                                                                                            Value = x.Id.ToString()
                                                                                                        }).ToList();

                if (makale != null)
                {
                    mdl.Id = makale.Id;
                    mdl.Baslik = makale.Baslik;
                    mdl.OkunmaSayisi = makale.OkunmaSayisi;
                    mdl.Tarih = makale.YazilmaTarihi;
                    mdl.Icerik = makale.Icerik;
                    mdl.Ozet = makale.Ozet;
                    mdl.KategoriAd = makale.Kategori.Ad;
                    mdl.KategoriId = makale.KategoriId;
                    mdl.Silindi = makale.Silindi;
                }

                return View(mdl);
            }
        }

        [HttpPost]
        public ActionResult MakaleEkle(ViewModelMakale model)
        {
            Makale mkl;
            using (MvcBlogContext context = new MvcBlogContext())
            {
                if (model.Id > 0)
                {//update
                    mkl = context.Makaleler.Find(model.Id);
                }
                else
                {//insert
                    mkl = new Makale();
                    mkl.YazilmaTarihi = DateTime.Now;
                    context.Makaleler.Add(mkl);
                }
                //AutoMapper
                mkl.Baslik = model.Baslik;
                mkl.Icerik = model.Icerik;
                mkl.KategoriId = model.KategoriId;
                mkl.Ozet = model.Ozet;
                mkl.Silindi = model.Silindi;

                context.SaveChanges();

                return RedirectToAction("MakaleListele");
            }
        }

        #endregion

        #region KategoriIslemleri

        public ActionResult KategoriListele()
        {
            using (MvcBlogContext context = new MvcBlogContext())
            {
                List<ViewModelKategori> kategoriler = context.Kategoriler.Select(x => new ViewModelKategori
                 {
                     Id = x.Id,
                     Ad = x.Ad
                 }).ToList();

                return View(kategoriler);
            }
        }

        public ActionResult KategoriEkle(int id)
        {
            ViewModelKategori model = new ViewModelKategori();
            using (MvcBlogContext context = new MvcBlogContext())
            {
                Kategori kategori = context.Kategoriler.Find(id);

                if (kategori != null)
                {
                    model.Id = kategori.Id;
                    model.Ad = kategori.Ad;
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult KategoriEkle(ViewModelKategori mdl)
        {
            Kategori ktg;
            using (MvcBlogContext context = new MvcBlogContext())
            {
                if (mdl.Id > 0)
                {
                    ktg = context.Kategoriler.Find(mdl.Id);
                }
                else
                {
                    ktg = new Kategori();
                    context.Kategoriler.Add(ktg);
                }
                ktg.Ad = mdl.Ad;
                context.SaveChanges();

                return RedirectToAction("KategoriListele");
            }
        }

        #endregion

    }
}
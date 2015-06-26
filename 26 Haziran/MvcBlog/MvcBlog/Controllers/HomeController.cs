using System;
using System.Linq;
using System.Web.Mvc;
using MvcBlog.EF;
using MvcBlog.Entities;
using MvcBlog.Models;

namespace MvcBlog.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {

        //Action ya da Controller üzerine yazılabilir. Hataları yakalar.
        //[HandleError]
        public ActionResult Index()
        {
            //Convert.ToInt32("dsgsdgsdfg");
            using (BlogContext context = new BlogContext())
            {
                var makaleler = context.Makaleler
                    .Where(x => !x.Pasif)
                    .Select(x => new ViewModelMakale
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
                })
                .OrderByDescending(x => x.Id)
                .ToList();
                return View(makaleler);
            }
        }

        public ActionResult _KategoriPartial()
        {
            using (var context = new BlogContext())
            {
                var kategoriler = context.Kategoriler.Select(x => new ViewModelKategori
                    {
                        Id = x.Id,
                        Ad = x.Ad
                    }).ToList();

                return PartialView(kategoriler);
            }
        }

        public ActionResult Detay(int id)
        {
            using (BlogContext context = new BlogContext())
            {
                var makale = context.Makaleler.Find(id);
                ViewModelMakale mdl = new ViewModelMakale();
                mdl.Id = makale.Id;
                mdl.Baslik = makale.Baslik;
                mdl.OkunmaSayisi = ++makale.OkunmaSayisi;
                mdl.Icerik = makale.Icerik;
                mdl.Tarih = makale.EklenmeTarihi;
                mdl.Dislike = makale.Dislike;
                mdl.Like = makale.Like;
                mdl.KategoriAd = makale.Kategori.Ad;

                mdl.Etiketler = context.MakaleEtiketler
                                                          .Where(x => x.MakaleId == id)
                                                          .Select(x => new ViewModelMakaleEtiket
                                                          {
                                                              MakaleId = x.MakaleId,
                                                              EtiketAd = x.Etiket.Ad,
                                                              EtiketId = x.EtiketId
                                                          }).ToList();

                context.SaveChanges();

                return View(mdl);
            }
        }

        //aşağıdaki işlem yukarıdaki Index Action' ı kullanılarak da yapılabilir.
        public ActionResult KategoriyeGoreMakaleleriGetir(int id)
        {
            using (BlogContext context = new BlogContext())
            {
                var makaleler = context.Makaleler.Where(x => x.KategoriId == id).Select(x => new ViewModelMakale
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
                })
                .OrderByDescending(x => x.Id)
                .ToList();
                return View("Index", makaleler);
            }
        }



        //JSON RESULTS
        //Odev: Like & Dislike sonrası, pasif yap resimleri. Zıttı tıklanırsa, zıttından 1 düş diğerine 1 ekle
        public JsonResult YorumlariGetirByMakaleId(int id)
        {
            using (BlogContext context = new BlogContext())
            {
                var yorumlar = context.Yorumlar
                    .Where(x => x.MakaleId == id && x.Onay)
                    .Select(x => new ViewModelYorum
                    {
                        Id = x.Id,
                        EklenmeTarihiStr = x.EklenmeTarihi.ToString(),
                        Icerik = x.Icerik,
                        Yazan = x.Yazan
                    })
                    .OrderByDescending(x => x.Id)
                    .ToList();
                return Json(yorumlar);
            }
        }
        public JsonResult YorumYaz(ViewModelYorum mdl)
        {
            using (BlogContext context = new BlogContext())
            {
                var yeniYorum = new Yorum();
                yeniYorum.Icerik = mdl.Icerik.Trim();
                yeniYorum.MakaleId = mdl.MakaleId;
                yeniYorum.Yazan = mdl.Yazan;

                context.Yorumlar.Add(yeniYorum);
                context.SaveChanges();
                return Json("ok");
            }
        }
        public JsonResult LikeArttir(int id)
        {
            int likeCount = LikeDislikeArttir(id, "like");
            return Json(likeCount);

            //Get' e izin vermek için
            //return Json(likeCount, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DislikeArttir(int id)
        {
            return Json(LikeDislikeArttir(id, "dislike"));
        }

        private int LikeDislikeArttir(int makaleId, string type)
        {
            using (BlogContext context = new BlogContext())
            {
                int retVal = 0;
                var makale = context.Makaleler.Find(makaleId);
                if (makale != null)
                {
                    if (type == "like")
                    {
                        retVal = ++makale.Like;
                    }
                    else
                    {
                        retVal = ++makale.Dislike;
                    }
                    context.SaveChanges();
                }
                return retVal;
            }
        }

        public ActionResult MakaleleriGetirByEtiketId(int id)
        {
            using (BlogContext context = new BlogContext())
            {
                var etiketeGoreMakaleler = context.MakaleEtiketler.Where(x => x.EtiketId == id).Select(
                          x => new ViewModelMakale
                          {
                              Baslik = x.Makale.Baslik,
                              Ozet = x.Makale.Ozet,
                              Id = x.MakaleId,
                              KategoriId = x.Makale.KategoriId,
                              Dislike = x.Makale.Dislike,
                              Like = x.Makale.Like,
                              KategoriAd = x.Makale.Kategori.Ad,
                              OkunmaSayisi = x.Makale.OkunmaSayisi,
                              Tarih = x.Makale.EklenmeTarihi
                          }).OrderByDescending(x => x.Id).ToList();

                return View("Index", etiketeGoreMakaleler);
            }
        }
    }
}
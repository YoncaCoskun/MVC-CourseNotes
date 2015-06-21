using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CalisanController : Controller
    {
        //
        // GET: /Calisan/
        public ActionResult Index()
        {
            //Listeleme yapıldı.
            //EmployeeID,FirstName,LastName,Title,City
            //dbfirst teki kısmı kullanmak yerıne model olusturduk tekrardan ve ılgılı ozellıklerı ordan kullandık.
            //burda calısanları adlarını soyadlarını unvanlaruını sehırlerı lısteledık.
            NorthwindEntities context=new NorthwindEntities();

            var calisanlar = context.Employees.Select(
                x => new CalisanModel
                {                 
                   Sehir = x.City,
                   Unvan = x.Title,
                   Ad = x.FirstName,
                   Soyad = x.LastName,
                   CalisanId = x.EmployeeID

                }).ToList();

            //List<CalisanModel>liste=new List<CalisanModel>();
            
            //foreach (var item in calisanlar)
            //{
            //    CalisanModel cls=new CalisanModel()
            //    {
            //        //object initilizer
                    
            //        Sehir = item.City,
            //        Unvan = item.Title,
            //        Soyad = item.LastName,
            //        Ad = item.FirstName,
            //        CalisanId = item.EmployeeID

            //    };

                //cls.CalisanId = item.EmployeeID;
                //cls.Ad = item.FirstName;
                //cls.Soyad = item.LastName;
                //cls.Unvan = item.Title;
                //cls.Sehir = item.City;

                //liste.Add(cls);
          //  }
            return View(calisanlar);
        }

        public ActionResult Gor(int id)
        {
            if (id>0)
            {
                using (NorthwindEntities context = new NorthwindEntities())  //ıdisposable dan implemente edilmis oldugu ıcın hata vermeden burda kullanabıldık.
                {
                    Employee calisan = context.Employees.Find(id);
                    // Employee calisan = context.Employees.FirstOrDefault(x => x.EmployeeID == id);


                    CalisanModel model = new CalisanModel
                    {
                        CalisanId = calisan.EmployeeID,
                        Ad = calisan.FirstName,
                        Soyad = calisan.LastName,
                        Unvan = calisan.Title,
                        Sehir = calisan.City
                    };

                    return View(model);

                } 
            }
            return View();

        }

        public ActionResult Kaydet(CalisanModel model)
        {
            using (NorthwindEntities context=new NorthwindEntities())
            {
                Employee emp;
                if (model.CalisanId > 0)
                {
                    //guncelle

                    emp = context.Employees.Find(model.CalisanId);
                    
                }
                else
                {
                    //ekle
                    emp=new Employee();
                    context.Employees.Add(emp);


                }
                emp.FirstName = model.Ad;
                emp.LastName = model.Soyad;
                emp.Title = model.Unvan;
                emp.City = model.Sehir;

                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            using (NorthwindEntities context=new NorthwindEntities())
            {
             Employee emp=context.Employees.Find(id);
                context.Employees.Remove(emp);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
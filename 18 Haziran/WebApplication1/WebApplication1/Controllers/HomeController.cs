using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        string cnnStr = ConfigurationManager.ConnectionStrings["NorthCnn"].ConnectionString;

        public ActionResult AnaSayfa()
        {

            //sql e gidip product ları cekıp viewbag ıcıne koyup ılgılı vıew ı dondurdu.
            SqlConnection cnn = new SqlConnection(cnnStr);
            SqlCommand cmd = new SqlCommand("SELECT ProductId, ProductName, Unitprice, UnitsInstock FROM Products", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ViewBag.Urunler = dt.AsEnumerable();

            return View(); 
        }

        public ActionResult Yeni()
        {
            return View();
        }

        public ActionResult Goruntule(int id)
        {
            SqlConnection connect=new SqlConnection(cnnStr);
            SqlCommand command=new SqlCommand("select ProductName,UnitPrice,UnitsInStock from Products where ProductID=@id",connect);

            command.Parameters.AddWithValue("@id",id);

            connect.Open();
            SqlDataReader reader = command.ExecuteReader();

            UrunModel model=new UrunModel();
            model.UrunId = id;

            while (reader.Read())
            {
               model.UrunAd = reader["ProductName"].ToString();
                model.Fiyat = (decimal) reader["UnitPrice"];
                model.Stok = (short)reader["UnitsInStock"];

            }

            connect.Close();

            return View(model);
        }
        public ActionResult Kaydet(string urunAdi, decimal fiyat, int stok)
        {
            SqlConnection cnn = new  SqlConnection(cnnStr);
            SqlCommand cmd = new SqlCommand("INSERT INTO Products (Productname, UnitsInStock, Unitprice) VALUES (@name, @stock, @price)", cnn);
            cmd.Parameters.AddWithValue("@name",urunAdi );
            cmd.Parameters.AddWithValue("@stock", stok);
            cmd.Parameters.AddWithValue("@price",fiyat );
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            return RedirectToAction("AnaSayfa");  //dogrudan controllerı anasayfayı cagırıyor.
        }

        //butona tıklayınca guncellenmesı cıın metot yapıcaz.

        public ActionResult Guncelle(UrunModel model)
        {
            SqlConnection connect=new SqlConnection(cnnStr);
            SqlCommand command = new SqlCommand("update Products set ProductName=@ad,UnitPrice=@fiyat,UnitsInStock=@stok where ProductID=@id", connect);

            command.Parameters.AddWithValue("@ad", model.UrunAd);
            command.Parameters.AddWithValue("@fiyat", model.Fiyat);
            command.Parameters.AddWithValue("@stok", model.Stok);
            command.Parameters.AddWithValue("@id", model.UrunId);

            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();

            return RedirectToAction("AnaSayfa");

        }
	}
}
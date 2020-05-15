using AutoShop.Models;
using AutoShop.Models.EntityDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoShop.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        // GET: Cart
        internal BazaPodataka autoShopBP;

        public CartController()
        {
            autoShopBP = new BazaPodataka();
        }
        public ActionResult Index()
        {
            Session["cart"] = AutoDeo.cart;
            return View("Index", (List<AutoDeo>)Session["cart"]);
        }

        public ActionResult GetCart(List<AutoDeo> list)
        {           
            return PartialView("CartProizvodi", list);
        }


        //  [Authorize]
        
        public ActionResult AddCart(int ID, int quantity)
        {
            AutoDeo ad = autoShopBP.getAutoDeoByID(ID);
            List<AutoDeo> listaSesija = (List<AutoDeo>)Session["cart"];
            if (listaSesija != null)
            {
                AutoDeo adSesija = listaSesija.Where(t => t.ID == ad.ID).FirstOrDefault();
                if (adSesija != null)
                {
                    if ((adSesija.quantity + quantity) <= adSesija.Kolicina)
                    {
                        adSesija.quantity += quantity;
                        return View("Index");
                    }
                    else
                    {
                        TempData["Error"] = "Artikal ste vec dodali u korpu, i njegova prethodna kolicina se sabira sa izabranom kolicinom, ali nema toliko artikla na stanju u magacinu!";
                        return RedirectToAction("Index", "Pocetna");
                    }
                }
                else
                {


                    if (ad.Kolicina >= quantity)
                    {
                        ad.quantity = quantity;
                        AutoDeo.cart.Add(ad);
                        Session["cart"] = AutoDeo.cart;
                        return View("Index");
                    }
                    else
                    {
                        TempData["Error"] = "Izabranog proizvoda 'Naziv:" + ad.Naziv + ", Proizvodjac: " + ad.Proizvodjac + "' nema na stanju u trazenoj kolicini";
                        return RedirectToAction("Index", "Pocetna");
                    }
                }
            }
            else
            {
                if (ad.Kolicina >= quantity)
                {
                    ad.quantity = quantity;
                    AutoDeo.cart.Add(ad);
                    Session["cart"] = AutoDeo.cart;
                    return View("Index");
                }
                else
                {
                    TempData["Error"] = "Izabranog proizvoda 'Naziv:" + ad.Naziv + ", Proizvodjac: " + ad.Proizvodjac + "' nema na stanju u trazenoj kolicini";
                    return RedirectToAction("Index", "Pocetna");
                }
            }

            

        }

        [HttpPost]
        public ActionResult EditCart(int ID)
        {
            switch(Request["button"])
            {
                case "update":
                    AutoDeo editAD = AutoDeo.cart.Where(t => t.ID == ID).FirstOrDefault();
                    int quantity= int.Parse(Request[ID.ToString()]);
                    if (editAD.Kolicina >= quantity)
                    {
                        editAD.quantity = quantity;
                        Session["cart"] = AutoDeo.cart;
                        TempData["SuccessCart"] = "Uspesno ste promenili kolicinu proizvoda 'Naziv:" + editAD.Naziv + ", Proizvodjac: " + editAD.Proizvodjac + "'";
                    }
                    else
                    {
                        TempData["ErrorCart"]= "Izabranog proizvoda 'Naziv:" + editAD.Naziv + ", Proizvodjac: " + editAD.Proizvodjac + "' nema na stanju u trazenoj kolicini";
                    }
                    break;


                case "delete":
                    AutoDeo deleteAD = AutoDeo.cart.Where(t => t.ID == ID).FirstOrDefault();
                    AutoDeo.cart.Remove(deleteAD);
                    Session["cart"] = AutoDeo.cart;

                    break;
            }

            return View("Index");
        }

       


        //[HttpPost]
        //public JsonResult EditCart(string ID)
        //{
        //    int id = int.Parse(ID);
        //    string button = Request["button"];
        //    if(button== "delete")
        //    {
        //        AutoDeo deleteAD = AutoDeo.cart.Where(t => t.ID == id).FirstOrDefault();
        //        AutoDeo.cart.Remove(deleteAD);
        //        Session["cart"] = AutoDeo.cart;
        //        string viewContent = ConvertViewtoString("CartProizvodi", (List<AutoDeo>)Session["cart"]);
        //        return Json(new { PartialView = viewContent });
        //    }
        //    else
        //    {
        //        AutoDeo editAD = AutoDeo.cart.Where(t => t.ID == id).FirstOrDefault();
        //        editAD.quantity = int.Parse(Request[ID.ToString()]);
        //        Session["cart"] = AutoDeo.cart;
        //        string viewContent = ConvertViewtoString("CartProizvodi", (List<AutoDeo>)Session["cart"]);
        //        return Json(new { PartialView = viewContent });
        //    } 
             

        //}



        //private string ConvertViewtoString(string viewName, List<AutoDeo> lista)
        //{
        //    ViewData.Model = lista;
        //    using (StringWriter writer = new StringWriter())
        //    {
        //        ViewEngineResult vResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
        //        ViewContext vContext = new ViewContext(this.ControllerContext, vResult.View, ViewData, new TempDataDictionary(), writer);
        //        vResult.View.Render(vContext, writer);
        //        return writer.ToString();
        //    }
        //}
    }
}
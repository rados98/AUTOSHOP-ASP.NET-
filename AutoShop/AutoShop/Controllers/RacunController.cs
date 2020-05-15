using System;
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
    public class RacunController : Controller
    {
        // GET: Racun

        internal BazaPodataka autoShopBP;

        public RacunController()
        {
            autoShopBP = new BazaPodataka();
        }
        public ActionResult Index()
        {                 
            return View("Index");
        }

        [HttpPost]
        public ActionResult StampajRacun()
        {
            List<AutoDeo> listaUSesiji = (List<AutoDeo>)Session["cart"];

            if (listaUSesiji.Count != 0)
            {
                autoShopBP.stampajRacun(listaUSesiji);
                AutoDeo.cart.Clear();
                Session["cart"] = AutoDeo.cart;
                TempData["SuccessRacun"] = "Uspesno ste odstampali racun!";
                return RedirectToAction("Index", "Cart");
            }
            else
            {
                TempData["ErrorRacun"] = "Korpa je prazna, molim Vas dodajte proizvode!";
                return RedirectToAction("Index", "Cart");
            }
        }


        [HttpPost]
        public JsonResult SearchRacunByID(string IDRacuna)
        {
            int ID = int.Parse(IDRacuna);
            Racun racun = autoShopBP.getRacunByID(ID);
            if (racun != null)
            {
                ViewBag.Racun = racun;
                string viewContent = ConvertViewtoString("RacunPartial", racun.StavkaRacuna.ToList());
                return Json(new { PartialView = viewContent });
            }
            else
            {
                ViewBag.Racun = racun;
                List<StavkaRacuna> listaStavki = new List<StavkaRacuna>();
                string viewContent = ConvertViewtoString("RacunPartial", listaStavki);
                return Json(new { PartialView = viewContent });

            }
           
        }

        /// <summary>
        /// The ConvertViewtoString
        /// </summary>
        /// <param name="viewName">The viewName<see cref="string"/></param>
        /// <param name="lista">The lista<see cref="IPagedList{AutoDeo}"/></param>
        /// <returns>The <see cref="string"/></returns>
        private string ConvertViewtoString(string viewName, List<StavkaRacuna> lista)
        {
            ViewData.Model = lista;
            using (StringWriter writer = new StringWriter())
            {
                ViewEngineResult vResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext vContext = new ViewContext(this.ControllerContext, vResult.View, ViewData, new TempDataDictionary(), writer);
                vResult.View.Render(vContext, writer);
                return writer.ToString();
            }
        }
    }
}
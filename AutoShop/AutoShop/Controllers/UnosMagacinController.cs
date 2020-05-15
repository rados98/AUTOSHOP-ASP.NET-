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
    public class UnosMagacinController : Controller
    {
        // GET: UnosMagacin

        internal BazaPodataka autoShopBP;

        public UnosMagacinController()
        {
            autoShopBP = new BazaPodataka();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SearchUnosMagacinByDate(string datum)
        {
            DateTime date=DateTime.Now;
            if (DateTime.TryParse(datum, out date))
            {

                List<UnosMagacin> unosMagacin = autoShopBP.getUnoseByDate(date);
                if (unosMagacin != null)
                {

                    string viewContent = ConvertViewtoString("UnosMagacinPartial", unosMagacin);
                    return Json(new { PartialView = viewContent });
                }
                else
                {

                    List<UnosMagacin> unosMagacin2 = autoShopBP.getUnoseByDate(DateTime.Now);
                    string viewContent = ConvertViewtoString("UnosMagacinPartial", unosMagacin2);
                    return Json(new { PartialView = viewContent });

                }
            }
            else
            {
                List<UnosMagacin> unosMagacin = autoShopBP.getUnoseByDate(DateTime.Now);
                string viewContent = ConvertViewtoString("UnosMagacinPartial", unosMagacin);
                return Json(new { PartialView = viewContent });
            }

        }

        /// <summary>
        /// The ConvertViewtoString
        /// </summary>
        /// <param name="viewName">The viewName<see cref="string"/></param>
        /// <param name="lista">The lista<see cref="IPagedList{AutoDeo}"/></param>
        /// <returns>The <see cref="string"/></returns>
        private string ConvertViewtoString(string viewName, List<UnosMagacin> lista)
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
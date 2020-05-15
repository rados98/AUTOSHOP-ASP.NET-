namespace AutoShop.Controllers
{
    using AutoShop.Models;
    using AutoShop.Models.EntityDB;
    using PagedList;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="PocetnaController" />
    /// </summary>
   
        [Authorize]
    public class PocetnaController : Controller
    {
        /// <summary>
        /// Defines the autoShopBP
        /// </summary>
        internal BazaPodataka autoShopBP;
        
       

        /// <summary>
        /// Initializes a new instance of the <see cref="PocetnaController"/> class.
        /// </summary>
        public PocetnaController()
        {
            autoShopBP = new BazaPodataka();
              
        }

        /// <summary>
        /// The Index
        /// </summary>
        /// <param name="i">The i<see cref="int?"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Index(int? i)
        {
            if (i == null)
                i = 1;
            ViewBag.Help = i; //mora tu stojati za sad
            return View();
        }

        /// <summary>
        /// The GetAllAutoDeo
        /// </summary>
        /// <param name="i">The i<see cref="int?"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult GetAllAutoDeo(int? i)
        {
            List<AutoDeo> autoDelovi = autoShopBP.getAllAutoDeo();
            return PartialView("Proizvodi", autoDelovi.ToList().ToPagedList(i ?? 1, 6));
        }

        /// <summary>
        /// The SearchAutoDelove
        /// </summary>
        /// <param name="proizvodjac">The proizvodjac<see cref="string"/></param>
        /// <param name="i">The i<see cref="int?"/></param>
        /// <returns>The <see cref="JsonResult"/></returns>
        [HttpPost]
        public JsonResult SearchAutoDelove(string proizvodjac, int? i)
        {
            if (proizvodjac == "")
            {
                List<AutoDeo> autoDelovi = autoShopBP.getAllAutoDeo();
                string viewContent = ConvertViewtoString("Proizvodi", autoDelovi.ToList().ToPagedList(i ?? 1, 6));
                return Json(new { PartialView = viewContent });
            }
            else
            {
                List<AutoDeo> autoDelovi = autoShopBP.searchAutoDeoByMarka(proizvodjac);
                string viewContent = ConvertViewtoString("Proizvodi", autoDelovi.ToList().ToPagedList(i ?? 1, 6));  //da li radi paginacija posle search-a?
                return Json(new { PartialView = viewContent });
            }
        }
        [HttpPost]
        public JsonResult SearchAutoDeloveID(string id, int? i)
        {
            int ID = int.Parse(id);
            if (ID == -1)
            {
                List<AutoDeo> autoDelovi = autoShopBP.getAllAutoDeo();
                string viewContent = ConvertViewtoString("Proizvodi", autoDelovi.ToList().ToPagedList(i ?? 1, 6));
                return Json(new { PartialView = viewContent });
            }
            else
            {
                List<AutoDeo> autoDelovi = autoShopBP.searchAutoDeoByID(ID);
                string viewContent = ConvertViewtoString("Proizvodi", autoDelovi.ToList().ToPagedList(i ?? 1, 6));  //da li radi paginacija posle search-a?
                return Json(new { PartialView = viewContent });
            }
        }

        /// <summary>
        /// The ConvertViewtoString
        /// </summary>
        /// <param name="viewName">The viewName<see cref="string"/></param>
        /// <param name="lista">The lista<see cref="IPagedList{AutoDeo}"/></param>
        /// <returns>The <see cref="string"/></returns>
        private string ConvertViewtoString(string viewName, IPagedList<AutoDeo> lista)
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

        [HttpPost]
        public ActionResult Redirect(int ID)
        {
            string button = Request["button"].ToString();
            int quantity = int.Parse(Request[ID.ToString()]);
            if (button=="cart")
            {
                return RedirectToAction("AddCart", "Cart", new { ID = ID, quantity=quantity });
            }
           else if(button=="magacin")
            {
                return RedirectToAction("AddMagacin", "Pocetna", new { ID = ID, quantity = quantity });
            }
            else if(button=="delete")
            {
                return RedirectToAction("DeleteAutoDeo", "Pocetna", new { ID = ID});
            }
            else
            {
                return RedirectToAction("EditAutoDeo", "Pocetna", new { ID = ID });
            }
        }



        public ActionResult EditAutoDeo(int ID)
        {
            AutoDeo ad = autoShopBP.searchAutoDeoByID(ID).First();
            return View("EditAutoDeo", ad);
        }


        [HttpPost]
        public ActionResult EditAutoDeoPost(AutoDeo ad)
        {
            autoShopBP.editAutoDeoInSystem(ad);
            TempData["SuccessEdit"] = "Uspesno ste azurirali zahtevani proizvod u sistemu. Sifra proizvoda: " + ad.ID;
            return RedirectToAction("Index", "Pocetna");
        }

        public ActionResult AddMagacin(int ID, int quantity)
        {
            AutoDeo_Magacin autoDeoMagacin = autoShopBP.searchAutoDeoFromMagacin(ID);
            int stanje = 0;
            if(autoDeoMagacin != null)
            {
                autoDeoMagacin.Stanje += quantity; //ceo unos saljem da ga zameni sa vec postojecim u bazi
                stanje = autoDeoMagacin.Stanje;
                autoShopBP.editStanjeAutoDeoMagacin(autoDeoMagacin);
                autoShopBP.addUnosMagacin(autoDeoMagacin, quantity);
                
            }
            else
            {
                AutoDeo_Magacin adM = new AutoDeo_Magacin()
                {
                    IDMagacin = 1,
                    IDAutoDeo = ID,
                    Stanje = quantity
                };
                stanje = adM.Stanje;
                autoShopBP.addAutodeoinMagacin(adM);
                autoShopBP.addUnosMagacin(adM, quantity);
            }

            AutoDeo ad = autoShopBP.searchAutoDeoByID(ID).FirstOrDefault();
            TempData["SuccessAutoDeoMagacin"] = "Uspesno ste uneli proizvod u magacin. Sifra = " + ad.ID + ", Naziv = " + ad.Naziv + ", Uneta kolicina: " + quantity.ToString() +
                ", Ukupno na stanju: " + stanje;
            return RedirectToAction("Index", "Pocetna");

            
            
        }

        public ActionResult DeleteAutoDeo(int ID)
        {
            AutoDeo_Magacin autoDeoMagacin = autoShopBP.searchAutoDeoFromMagacin(ID);
            AutoDeo ad = autoShopBP.searchAutoDeoByID(ID).FirstOrDefault();
            if(autoDeoMagacin!=null)
            {
                if(autoDeoMagacin.Stanje==0)
                {
                    autoShopBP.deleteAutoDeo(ad);
                    TempData["SuccessDeleteAutoDeo"] = "Uspesno ste obrisali proizvod iz sistema. Sifra = " + ad.ID + ", Naziv = " + ad.Naziv;
                    return RedirectToAction("Index", "Pocetna");
                }
                else
                {
                    autoDeoMagacin.Stanje = 0;
                    autoShopBP.editStanjeAutoDeoMagacin(autoDeoMagacin);
                    TempData["SuccessDeleteAutoDeo"] = "Uspesno ste obrisali proizvod iz magacina. Sifra = " + ad.ID + ", Naziv = " + ad.Naziv;
                    return RedirectToAction("Index", "Pocetna");
                }
                
            }
            else
            {
                autoShopBP.deleteAutoDeo(ad);
                TempData["SuccessDeleteAutoDeo"] = "Uspesno ste obrisali proizvod iz sistema. Sifra = " + ad.ID + ", Naziv = " + ad.Naziv;
                return RedirectToAction("Index", "Pocetna");
            }
        }

        //Dodavanje novog proizvoda u sistem

        public ActionResult NewAutoDeo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewAutoDeoPost(AutoDeo autoDeo)
        {

            autoShopBP.addAutoDeoInSystem(autoDeo);
            TempData["SuccessAddNewAutoDeoInSystem"] = "Uspesno ste dodali novi auto deo u sistem!";
            return RedirectToAction("Index", "Pocetna");
        }


        

        /// <summary>
        /// The AddCart
        /// </summary>
        /// <param name="IDAutoDeo">The IDAutoDeo<see cref="int"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        
       // [Authorize]  //koristi se kao middleware u laravelu
       
    }
}

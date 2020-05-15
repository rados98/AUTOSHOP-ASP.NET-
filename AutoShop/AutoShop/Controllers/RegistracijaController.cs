using AutoShop.Models;
using AutoShop.Models.EntityDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AutoShop.Controllers
{
   
    public class RegistracijaController : Controller
    {
        // GET: Registracija
        internal BazaPodataka autoShopBP;


        public RegistracijaController()
        {
            autoShopBP = new BazaPodataka();
        }

        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                foreach (string s in autoShopBP.getRolesByUserName(User.Identity.Name))
                {
                    TempData["Roles"] += s + ";";
                }
            }
            return View();
        }

        [HttpPost]

        public ActionResult Login(User user)  //post metoda pogleda Index
        {
            if(autoShopBP.isValid(user))
            {
               
                FormsAuthentication.SetAuthCookie(autoShopBP.findUserNameByEmail(user.Email), false);              
                return RedirectToAction("Index", "Pocetna");
            }
            else
            {
                ModelState.AddModelError("", "Neuspesno logovanje!");
                if (autoShopBP.findUserNameByEmail(user.Email) == "")
                    ModelState.AddModelError("Email", "Nepoznat email!");
              
                return View("Index");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

     


       

        
    }
}
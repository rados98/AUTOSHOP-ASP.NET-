using AutoShop.Models;
using AutoShop.Models.EntityDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoShop.Controllers
{ 
    [Authorize(Roles="Super admin")]
    public class UserController : Controller
    {

        internal BazaPodataka autoShopBP;
        public UserController()
        {
            autoShopBP = new BazaPodataka();
        }
        public ActionResult Index()
        {
            List<User> listaUsera = autoShopBP.getAllUsers();
            return View("Index", listaUsera);
        }

      
        public ActionResult NewUser()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateNewUser(User user)
        {
            if (autoShopBP.addUser(user))
            {
                TempData["SuccessAddNewuser"] = "Uspesno ste dodali novog korisnika";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "Postoji korisnik sa unetim email-om i ili imenom, molim unesite validne podatke!");
                return RedirectToAction("NewUser");
            }
        }
      

        public ActionResult DeleteUser(int id)
        {
            autoShopBP.deleteUserByID(id);
            TempData["SuccessDeleteUser"] = "Uspesno ste obrisali korisnika";
            return RedirectToAction("Index", "User");
        }
    }
}
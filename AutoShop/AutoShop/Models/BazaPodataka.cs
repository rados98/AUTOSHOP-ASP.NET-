using AutoShop.Models.EntityDB;
using System.Collections.Generic;
using System.Linq;
using System;
namespace AutoShop.Models
{
    

    /// <summary>
    /// Defines the <see cref="BazaPodataka" />
    /// </summary>
    public class BazaPodataka
    {
        /// <summary>
        /// Defines the AutoShopDB
        /// </summary>
        internal AutoShopEntities AutoShopDB = new AutoShopEntities();

        /// <summary>
        /// The getAllAutoDeo
        /// </summary>
        /// <returns>The <see cref="List{AutoDeo}"/></returns>
        public List<AutoDeo> getAllAutoDeo()
        {
            List<AutoDeo> autoDelovi = new List<AutoDeo>();
            foreach (AutoDeo ad in AutoShopDB.AutoDeo)
            {
                AutoDeo_Magacin adm = AutoShopDB.AutoDeo_Magacin.Where(t => t.IDAutoDeo == ad.ID).FirstOrDefault();
                if (adm != null)
                {
                    ad.Kolicina = adm.Stanje;
                }
                else
                {
                    ad.Kolicina = 0;
                }
                autoDelovi.Add(ad);
            }
            return autoDelovi;
        }

        public void addAutoDeoInSystem(AutoDeo autoDeo)
        {
            AutoShopDB.AutoDeo.Add(autoDeo);
            AutoShopDB.SaveChanges();
        }

        public void editAutoDeoInSystem(AutoDeo autodeo)
        {
            AutoDeo ad = AutoShopDB.AutoDeo.Where(t => t.ID == autodeo.ID).FirstOrDefault();
            ad.Naziv = autodeo.Naziv;
            ad.Proizvodjac = autodeo.Proizvodjac;
            ad.GodProizvodnje = autodeo.GodProizvodnje;
            ad.JedCena = autodeo.JedCena;
            ad.Opis = autodeo.Opis;
            AutoShopDB.SaveChanges();
        }

        /// <summary>
        /// The getAutoDeoByID
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="AutoDeo"/></returns>
        public AutoDeo getAutoDeoByID(int id)
        {
            AutoDeo ad = AutoShopDB.AutoDeo.Where(t => t.ID == id).FirstOrDefault();
            AutoDeo_Magacin adm = AutoShopDB.AutoDeo_Magacin.Where(t => t.IDAutoDeo == ad.ID).FirstOrDefault();
            if (adm != null)
            {
                ad.Kolicina = adm.Stanje;
            }
            else
            {
                ad.Kolicina = 0;
            }
            return ad;
        }

        /// <summary>
        /// The searchAutoDeoByMarka
        /// </summary>
        /// <param name="marka">The marka<see cref="string"/></param>
        /// <returns>The <see cref="List{AutoDeo}"/></returns>
        public List<AutoDeo> searchAutoDeoByMarka(string marka)
        {
            List<AutoDeo> autoDelovi = new List<AutoDeo>();
            // foreach (AutoDeo ad in AutoShopDB.AutoDeo.Where(t => t.Proizvodjac.ToLower() == marka.ToLower()))
            foreach (AutoDeo ad in AutoShopDB.AutoDeo.Where(t => t.Proizvodjac.StartsWith(marka.ToLower())))
                {
                AutoDeo_Magacin adm = AutoShopDB.AutoDeo_Magacin.Where(t => t.IDAutoDeo == ad.ID).FirstOrDefault();
                if (adm != null)
                {
                    ad.Kolicina = adm.Stanje;
                }
                else
                {
                    ad.Kolicina = 0;
                }
                autoDelovi.Add(ad);
            }
            return autoDelovi;
        }
        public List<AutoDeo> searchAutoDeoByID(int ID)
        {
            List<AutoDeo> autoDelovi = new List<AutoDeo>();
            // foreach (AutoDeo ad in AutoShopDB.AutoDeo.Where(t => t.Proizvodjac.ToLower() == marka.ToLower()))
            AutoDeo ad = AutoShopDB.AutoDeo.Where(t => t.ID == ID).FirstOrDefault();
            if (ad != null)
            {
                AutoDeo_Magacin adm = AutoShopDB.AutoDeo_Magacin.Where(t => t.IDAutoDeo == ad.ID).FirstOrDefault();
                if (adm != null)
                {
                    ad.Kolicina = adm.Stanje;
                }
                else
                {
                    ad.Kolicina = 0;
                }

                autoDelovi.Add(ad);
            }
            

                return autoDelovi;
         
        }

        public void deleteAutoDeo(AutoDeo ad)
        {
            AutoShopDB.AutoDeo.Remove(ad);
            AutoShopDB.SaveChanges();
        }

        // pocetak USER Funckije!!
        public bool isValid(User user)
        {
            bool isValid = AutoShopDB.User.Any(t => t.Email == user.Email && t.Password == user.Password);
            return isValid;
        }

        public bool isExist(User user)
        {
            bool isValid = AutoShopDB.User.Any(t => t.Email == user.Email || t.Name==user.Name);
            return isValid;
        }

        public bool addUser(User user)
        {

            if (isExist(user))
                return false;
            else
            {
                AutoShopDB.User.Add(user);
                Role_User ru = new Role_User()
                {
                    IDRole = 1,
                    IDUser = findIDByEmail(user.Email)
                };
                AutoShopDB.Role_User.Add(ru);

                AutoShopDB.SaveChanges();
                return true;
            }
        }

        public List<User> getAllUsers()
        {
            return AutoShopDB.User.ToList();
        }

        public void deleteUserByID(int id)
        {
            User user = AutoShopDB.User.Where(t => t.ID == id).FirstOrDefault();
            AutoShopDB.User.Remove(user);
            AutoShopDB.SaveChanges();
        }
        public string findUserNameByEmail(string email)
        {
            User user = AutoShopDB.User.Where(t => t.Email == email).FirstOrDefault();
            if (user == null)
                return "";
            else
                return user.Name;
        }
        public int findIDByEmail(string email)
        {
            User user = AutoShopDB.User.Where(t => t.Email == email).FirstOrDefault();
            if (user == null)
                return 0;
            else
                return user.ID;
        }

        public User findUserByName(string name)
        {
            User user = AutoShopDB.User.Where(t => t.Name == name).FirstOrDefault();
            return user;
        }

        public string[] getRolesByUserName(string name)
        {
            User user = AutoShopDB.User.Where(t => t.Name == name).FirstOrDefault();

            return user.Role_User.Select(t=>t.Role.Name).ToArray();
        }

          //Kraj USER funckija!

            //Pocetak Autodeo_magacin funkcija

        public AutoDeo_Magacin searchAutoDeoFromMagacin(int ID)
        {
            AutoDeo_Magacin adM = AutoShopDB.AutoDeo_Magacin.Where(t => t.IDAutoDeo == ID).FirstOrDefault();
            return adM;
        }

        public void addUnosMagacin(AutoDeo_Magacin adm, int quantity)
        {
            DateTime date = DateTime.Now;
            TimeSpan time = DateTime.Now.TimeOfDay;
            string dateString = String.Format("{0:yyyy-MM-dd}", date);
            UnosMagacin um = new UnosMagacin()
            {
                IDMagacin = adm.IDMagacin,
                IDAutoDeo = adm.IDAutoDeo,
                Kolicina = quantity,
                Datum = date,
                Vreme = time
                

            };
            AutoShopDB.UnosMagacin.Add(um);
            AutoShopDB.SaveChanges();
        }

        public void addAutodeoinMagacin(AutoDeo_Magacin adM)
        {

            AutoShopDB.AutoDeo_Magacin.Add(adM);
            AutoShopDB.SaveChanges();

        }

        public void editStanjeAutoDeoMagacin(AutoDeo_Magacin adM)
        {
            AutoDeo_Magacin autodeoMagacin = AutoShopDB.AutoDeo_Magacin.Where(t => t.IDAutoDeo == adM.IDMagacin).FirstOrDefault();
            autodeoMagacin = adM;
            AutoShopDB.SaveChanges();
        }

        public List<UnosMagacin> getUnoseByDate(DateTime date)
        {
            DateTime provera = DateTime.Now;
            if (date != provera)
            {
                List<UnosMagacin> lista = AutoShopDB.UnosMagacin.Where(t => t.Datum == date).ToList();
                return lista;
            }
            else
            {
                List<UnosMagacin> lista = AutoShopDB.UnosMagacin.ToList();
                return lista;
            }
            
        }


        //kraj Autodeo_magacin funckija

        public void dodajRacun(float ukupnaVrednost)
        {
            DateTime date = DateTime.Now;
            TimeSpan time = DateTime.Now.TimeOfDay;
            Racun noviRacun = new Racun()
            {
                Datum = date,
                Vreme = time,
                UkupnaVrednost = ukupnaVrednost
            };
            AutoShopDB.Racun.Add(noviRacun);
            AutoShopDB.SaveChanges();
            
        }

        public void stampajRacun(List<AutoDeo> listaSesija)
        {
            float ukupnaVrednost = getUkupnaVrednost(listaSesija);
            dodajRacun(ukupnaVrednost);
            Racun racun=AutoShopDB.Racun.OrderByDescending(p => p.ID).FirstOrDefault();
            
           
            foreach (AutoDeo ad in listaSesija)
            {
                AutoDeo_Magacin adM = searchAutoDeoFromMagacin(ad.ID);
                StavkaRacuna stavkaRacuna = new StavkaRacuna()
                {
                    IDRacuna = racun.ID,
                    IDMagacin = adM.IDMagacin,
                    IDAutoDeo = adM.IDAutoDeo,
                    Kolicina = ad.quantity,
                    JedCena = ad.JedCena,
                    Vrednost = ad.quantity*ad.JedCena

                };
                AutoShopDB.StavkaRacuna.Add(stavkaRacuna);
                adM.Stanje -= ad.quantity;
            }
            
            AutoShopDB.SaveChanges();

             
        }

        public float getUkupnaVrednost(List<AutoDeo>listaSesija)
        {
            float ukupnaVrednost = 0;

            foreach(AutoDeo ad in listaSesija)
            {
                ukupnaVrednost += (float)(ad.quantity * ad.JedCena);
            }
            return ukupnaVrednost;
        }

        public Racun getRacunByID(int IDRacuna)
        {

            Racun racun = AutoShopDB.Racun.Where(p => p.ID== IDRacuna).FirstOrDefault();
            return racun;
        }






        //kraj Racun funckija
    }
}

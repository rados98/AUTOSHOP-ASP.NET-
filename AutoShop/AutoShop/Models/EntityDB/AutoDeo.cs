//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoShop.Models.EntityDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class AutoDeo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AutoDeo()
        {
            this.AutoDeo_Magacin = new HashSet<AutoDeo_Magacin>();
        }
    
        public int ID { get; set; }

        [Required(ErrorMessage = "Morate uneti naziv")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Morate uneti proizvodjaca")]
        public string Proizvodjac { get; set; }

        [Required(ErrorMessage = "Morate uneti godinu proizvodnje")]
        [Range(1990, 2020, ErrorMessage = "Godina proizvodnje mora biti 1990-2020")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Molim vas unesite validnu godinu")]
        public string GodProizvodnje { get; set; }

        [Required(ErrorMessage = "Morate uneti cenu")]
        [Range(0f, double.MaxValue, ErrorMessage = "Cena mora biti broj")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Molim vas unesite validan broj")]
        public double JedCena { get; set; }

        public int Kolicina { get; set; } //dodato,predstavlja Stanje u magacinu

       
        public string Opis { get; set; }

        public int quantity { get; set; } = 1;//dodato, predstavlja kolicinu koja treba da se naruci

        public static List<AutoDeo> cart = new List<AutoDeo>();
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AutoDeo_Magacin> AutoDeo_Magacin { get; set; }
    }
}
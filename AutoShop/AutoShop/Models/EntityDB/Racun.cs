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
    
    public partial class Racun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Racun()
        {
            this.StavkaRacuna = new HashSet<StavkaRacuna>();
        }
    
        public int ID { get; set; }
        public System.DateTime Datum { get; set; }
        public System.TimeSpan Vreme { get; set; }
        public double UkupnaVrednost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StavkaRacuna> StavkaRacuna { get; set; }
    }
}

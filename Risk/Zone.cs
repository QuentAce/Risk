//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Risk
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zone
    {
        public Zone()
        {
            this.Unite = new HashSet<Unite>();
            this.Zone1 = new HashSet<Zone>();
            this.Zone2 = new HashSet<Zone>();
        }
    
        public int id_zone { get; set; }
        public string nom_zone { get; set; }
        public int coordonneesX_zone { get; set; }
        public int coordonneesY_zone { get; set; }
        public Nullable<int> zone_toMonde { get; set; }
    
        public virtual New_Monde New_Monde { get; set; }
        public virtual ICollection<Unite> Unite { get; set; }
        public virtual ICollection<Zone> Zone1 { get; set; }
        public virtual ICollection<Zone> Zone2 { get; set; }
    }
}

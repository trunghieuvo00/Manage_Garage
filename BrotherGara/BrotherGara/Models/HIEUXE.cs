//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrotherGara.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HIEUXE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HIEUXE()
        {
            this.NOIDUNGDOANHSOes = new HashSet<NOIDUNGDOANHSO>();
            this.TIEPNHANs = new HashSet<TIEPNHAN>();
        }
    
        public string MaHieuXe { get; set; }
        public string TenHieuXe { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOIDUNGDOANHSO> NOIDUNGDOANHSOes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIEPNHAN> TIEPNHANs { get; set; }
    }
}

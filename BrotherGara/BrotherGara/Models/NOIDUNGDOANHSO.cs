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
    
    public partial class NOIDUNGDOANHSO
    {
        public string MaNDDS { get; set; }
        public string MaPDS { get; set; }
        public string MaPTT { get; set; }
        public string MaHieuXe { get; set; }
        public Nullable<int> SoLuotSua { get; set; }
        public Nullable<decimal> ThanhTien { get; set; }
        public Nullable<double> TiLe { get; set; }
    
        public virtual HIEUXE HIEUXE { get; set; }
        public virtual PHIEUDOANHSO PHIEUDOANHSO { get; set; }
        public virtual PHIEUTHUTIEN PHIEUTHUTIEN { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComputerDIY
{
    using System;
    using System.Collections.Generic;
    
    public partial class SOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SOrder()
        {
            this.SOrderItems = new HashSet<SOrderItem>();
        }
    
        public int Or_ID { get; set; }
        public System.DateTime Or_date { get; set; }
        public string Or_ornum { get; set; }
        public decimal Or_totalamount { get; set; }
        public int Or_EmID { get; set; }
        public int Or_CmID { get; set; }
        public Nullable<int> Or_Pro { get; set; }
    
        public virtual Scustomer Scustomer { get; set; }
        public virtual Semployee Semployee { get; set; }
        public virtual Spromotion Spromotion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOrderItem> SOrderItems { get; set; }
    }
}

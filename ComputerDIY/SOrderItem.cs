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
    
    public partial class SOrderItem
    {
        public int It_ID { get; set; }
        public int It_OrderID { get; set; }
        public int It_productNID { get; set; }
        public string It_productID { get; set; }
        public decimal It_unitprice { get; set; }
        public int It_Quantity { get; set; }
    
        public virtual SOrder SOrder { get; set; }
        public virtual Sproduct Sproduct { get; set; }
    }
}

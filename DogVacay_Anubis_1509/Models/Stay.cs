//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DogVacay_Anubis_1509.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Stay
    {
        public int StayId { get; set; }
        public Nullable<short> StayDays { get; set; }
        
        public Nullable<System.DateTime> StartDate { get; set; }
        
        public Nullable<System.DateTime> EndDate { get; set; }
        public int DogId { get; set; }
    
        public virtual Dog Dog { get; set; }
    }
}

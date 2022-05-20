using System;
using System.Collections.Generic;

#nullable disable

namespace RealEstateGui.Models
{
    public partial class Realestate
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public long SellerId { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public bool Freeofcharge { get; set; }
        public string ImageUrl { get; set; }
        public int? Area { get; set; }
        public int? Rooms { get; set; }
        public int? Floors { get; set; }
        public string Latlong { get; set; }

        public virtual Category Category { get; set; }
        public virtual Seller Seller { get; set; }
    }
}

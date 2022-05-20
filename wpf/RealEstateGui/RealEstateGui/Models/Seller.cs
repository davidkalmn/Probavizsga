using System;
using System.Collections.Generic;

#nullable disable

namespace RealEstateGui.Models
{
    public partial class Seller
    {
        public Seller()
        {
            Realestates = new HashSet<Realestate>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Realestate> Realestates { get; set; }
    }
}

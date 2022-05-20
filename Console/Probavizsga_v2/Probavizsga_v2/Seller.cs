using System;
using System.Collections.Generic;
using System.Text;

namespace Probavizsga_v2
{
    class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        int id = 0;
        public Seller(string adat1, string adat2)
        {
            Id = id;
            Name = adat1;
            Phone = adat2;
            id++;
        }
    }
}

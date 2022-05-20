using System;
using System.Collections.Generic;
using System.Text;

namespace Probavizsga_v2
{
    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        int id = 0;
        public Category(string name)
        {
            Name = name;
            Id = id;
            id++;
        }
    }
}

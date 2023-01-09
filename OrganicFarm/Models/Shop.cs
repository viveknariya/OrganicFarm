using System;
using System.Collections.Generic;

namespace OrganicFarm.Models
{
    public partial class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public List<Product> Product { get; set; }
    }
}

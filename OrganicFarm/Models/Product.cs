using System;

namespace OrganicFarm.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Shop Shop { get; set; }
    }
}

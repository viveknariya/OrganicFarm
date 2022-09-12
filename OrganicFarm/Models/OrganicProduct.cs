using System;
using System.Collections.Generic;

namespace OrganicFarm.Models
{
    public partial class OrganicProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string ProductType { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? OrganicShopId { get; set; }

        public virtual OrganicShop OrganicShop { get; set; }
    }
}

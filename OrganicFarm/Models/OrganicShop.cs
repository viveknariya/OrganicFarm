using System;
using System.Collections.Generic;

namespace OrganicFarm.Models
{
    public partial class OrganicShop
    {
        public OrganicShop()
        {
            OrganicProduct = new HashSet<OrganicProduct>();
        }

        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string Country { get; set; }
        public string ShopAddress { get; set; }

        public virtual ICollection<OrganicProduct> OrganicProduct { get; set; }
    }
}

using OrganicFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicFarm.OrganicFarmData
{
     public interface IOrganicProduct
    {
        List<OrganicProduct> getOrganicProduct();

        List<OrganicProduct> getOrganicProductByType(string type);

        List<OrganicProduct> EditProductPriceByShop(int shopid, int increment);

        OrganicProduct getOrganicProductWithShop();

        OrganicProduct AddOrganicProduct(OrganicProduct OrganicProduct);

        void DeleteOrganicProduct(OrganicProduct OrganicProduct);

        OrganicProduct EditOrganicProduct(OrganicProduct OrganicProduct);

        OrganicProduct getOrganicProduct(int id);
    }
}

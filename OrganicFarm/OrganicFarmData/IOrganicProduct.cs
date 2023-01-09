using OrganicFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicFarm.OrganicFarmData
{
     public interface IOrganicProduct
    {
        List<Product> getOrganicProduct();

        List<Product> getOrganicProductByType(string type);

        List<Product> EditProductPriceByShop(int shopid, int increment);

        Product getOrganicProductWithShop();

        Product AddOrganicProduct(Product OrganicProduct);

        void DeleteOrganicProduct(Product OrganicProduct);

        Product EditOrganicProduct(Product OrganicProduct);

        Product getOrganicProduct(int id);
    }
}

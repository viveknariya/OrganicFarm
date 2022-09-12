using OrganicFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicFarm.OrganicFarmData
{
    public class ProductAccess : IOrganicProduct
    {
        private ShopContext _shopContext;
        public ProductAccess(ShopContext shopcontext)
        {
            _shopContext = shopcontext;
        }
        public OrganicProduct AddOrganicProduct(OrganicProduct organicProduct)
        {
            _shopContext.OrganicProduct.Add(organicProduct);
            _shopContext.SaveChanges();
            return organicProduct;
        }

        public void DeleteOrganicProduct(OrganicProduct organicProduct)
        {
            _shopContext.OrganicProduct.Remove(organicProduct);
            _shopContext.SaveChanges();
        }

        public OrganicProduct EditOrganicProduct(OrganicProduct organicProduct)
        {
            var p = getOrganicProduct(organicProduct.ProductId);
            p.ProductName = organicProduct.ProductName;
            p.ProductType = organicProduct.ProductType;
            p.Price = organicProduct.Price;
            p.ExpiryDate = organicProduct.ExpiryDate;
            p.OrganicShopId = organicProduct.OrganicShopId;

            _shopContext.OrganicProduct.Update(p);
            _shopContext.SaveChanges();

            return p;
        }

        public List<OrganicProduct> EditProductPriceByShop(int shopid, int increment = 10)
        {
            var lst = _shopContext.OrganicProduct.Where(p => p.OrganicShopId == shopid).ToList();
            foreach (OrganicProduct op in lst)
            {
                op.Price = op.Price + op.Price * increment / 100;
                _shopContext.OrganicProduct.Update(op);
                _shopContext.SaveChanges();
            }

            return lst;
        }

        public List<OrganicProduct> getOrganicProduct()
        {
            return _shopContext.OrganicProduct.ToList();
        }

        public OrganicProduct getOrganicProduct(int id)
        {
            return _shopContext.OrganicProduct.FirstOrDefault(p => p.ProductId == id);
        }

        public List<OrganicProduct> getOrganicProductByType(string type)
        {
            return _shopContext.OrganicProduct.Where(p => p.ProductType == type).ToList();
        }

        public OrganicProduct getOrganicProductWithShop()
        {
            throw new NotImplementedException();
        }
    }
}

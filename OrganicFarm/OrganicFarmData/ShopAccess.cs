using OrganicFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicFarm.OrganicFarmData
{
    public class ShopAccess : IOrganicShop
    {
        private ShopContext _shopContext;
        public ShopAccess(ShopContext shopcontext)
        {
            _shopContext = shopcontext;
        }

        public Shop AddOrganicShop(Shop organicShop)
        {
            _shopContext.OrganicShop.Add(organicShop);
            _shopContext.SaveChanges();
            return organicShop;
        }

        public void DeleteOrganicShop(Shop organicShop)
        {

            _shopContext.OrganicShop.Remove(organicShop);
            _shopContext.SaveChanges();
        }

        public Shop EditOrganicShop(Shop organicShop)
        {
            var o = getOrganicShop(organicShop.ShopId);
            o.ShopName = organicShop.ShopName;
            o.ShopAddress = organicShop.ShopAddress;
            o.Country = o.Country;
            

            _shopContext.OrganicShop.Update(o);
            _shopContext.SaveChanges();

            return o;
        }

        public List<Shop> getOrganicShop()
        {
            return _shopContext.OrganicShop.ToList();
        }

        public Shop getOrganicShop(int id)
        {
            return _shopContext.OrganicShop.FirstOrDefault(o => o.ShopId == id);
        }
    }
}

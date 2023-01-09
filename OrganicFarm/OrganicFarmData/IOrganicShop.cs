using OrganicFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicFarm.OrganicFarmData
{
    public interface IOrganicShop
    {
        List<Shop> getOrganicShop();

        Shop getOrganicShop(int id);

        Shop AddOrganicShop(Shop OrganicShop);

        void DeleteOrganicShop(Shop OrganicShop);

        Shop EditOrganicShop(Shop OrganicShop);
    }
}

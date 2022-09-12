using OrganicFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicFarm.OrganicFarmData
{
    public interface IOrganicShop
    {
        List<OrganicShop> getOrganicShop();

        OrganicShop getOrganicShop(int id);

        OrganicShop AddOrganicShop(OrganicShop OrganicShop);

        void DeleteOrganicShop(OrganicShop OrganicShop);

        OrganicShop EditOrganicShop(OrganicShop OrganicShop);
    }
}

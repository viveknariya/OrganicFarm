using OrganicFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicFarm.OrganicFarmData
{
    public interface IRole
    {
        List<TblRole> getTblRole();

        TblRole getTblRole(int id);

        TblRole AddTblRole(TblRole TblRole);

        void DeleteTblRole(TblRole TblRole);

        TblRole EditTblRole(TblRole TblRole);
    }
}

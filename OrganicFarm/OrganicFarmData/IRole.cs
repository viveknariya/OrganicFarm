using OrganicFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicFarm.OrganicFarmData
{
    public interface IRole
    {
        List<Role> getTblRole();

        Role getTblRole(int id);

        Role AddTblRole(Role TblRole);

        void DeleteTblRole(Role TblRole);

        Role EditTblRole(Role TblRole);
    }
}

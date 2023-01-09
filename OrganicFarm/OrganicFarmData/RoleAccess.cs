using OrganicFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicFarm.OrganicFarmData
{
    public class RoleAccess : IRole
    {
        private ShopContext _shopContext;
        public RoleAccess(ShopContext shopcontext)
        {
            _shopContext = shopcontext;
        }

        public Role AddTblRole(Role TblRole)
        {
            _shopContext.TblRole.Add(TblRole);
            _shopContext.SaveChanges();
            return TblRole;
        }

        public void DeleteTblRole(Role TblRole)
        {
            
            _shopContext.TblRole.Remove(TblRole);
            _shopContext.SaveChanges();
        }

        public Role EditTblRole(Role TblRole)
        {
            var role = getTblRole(TblRole.RoleId);
            role.RoleName = TblRole.RoleName;

            _shopContext.TblRole.Update(role);
            _shopContext.SaveChanges();

            return role;
        }

        public List<Role> getTblRole()
        {
            return _shopContext.TblRole.ToList();
        }

        public Role getTblRole(int id)
        {
            return _shopContext.TblRole.FirstOrDefault(r => r.RoleId == id);
        }
    }
}

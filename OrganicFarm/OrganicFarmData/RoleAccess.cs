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

        public TblRole AddTblRole(TblRole TblRole)
        {
            _shopContext.TblRole.Add(TblRole);
            _shopContext.SaveChanges();
            return TblRole;
        }

        public void DeleteTblRole(TblRole TblRole)
        {
            
            _shopContext.TblRole.Remove(TblRole);
            _shopContext.SaveChanges();
        }

        public TblRole EditTblRole(TblRole TblRole)
        {
            var role = getTblRole(TblRole.RoleId);
            role.RoleName = TblRole.RoleName;

            _shopContext.TblRole.Update(role);
            _shopContext.SaveChanges();

            return role;
        }

        public List<TblRole> getTblRole()
        {
            return _shopContext.TblRole.ToList();
        }

        public TblRole getTblRole(int id)
        {
            return _shopContext.TblRole.FirstOrDefault(r => r.RoleId == id);
        }
    }
}

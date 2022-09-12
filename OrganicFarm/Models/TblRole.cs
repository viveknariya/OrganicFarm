using System;
using System.Collections.Generic;

namespace OrganicFarm.Models
{
    public partial class TblRole
    {
        public TblRole()
        {
            Person = new HashSet<Person>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}

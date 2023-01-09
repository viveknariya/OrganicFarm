using System;
using System.Collections.Generic;

namespace OrganicFarm.Models
{
    public partial class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Person { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace OrganicFarm.Models
{
    public partial class Person
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string Ppassword { get; set; }
        public string EmailId { get; set; }
        public string City { get; set; }
        public int? RoleId { get; set; }

        public virtual TblRole Role { get; set; }
    }
}

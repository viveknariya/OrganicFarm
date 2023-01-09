using OrganicFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicFarm.OrganicFarmData
{
    public interface IPerson
    {
        List<User> getPerson();

        User getPerson(int id);

        User AddPerson(User Person);

        void DeletePerson(User Person);

        User EditPerson(User Person);
    }
}

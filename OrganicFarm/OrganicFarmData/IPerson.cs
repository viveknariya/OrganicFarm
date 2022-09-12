using OrganicFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicFarm.OrganicFarmData
{
    public interface IPerson
    {
        List<Person> getPerson();

        Person getPerson(int id);

        Person AddPerson(Person Person);

        void DeletePerson(Person Person);

        Person EditPerson(Person Person);
    }
}

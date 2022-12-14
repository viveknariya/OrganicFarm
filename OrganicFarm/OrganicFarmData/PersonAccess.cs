using OrganicFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicFarm.OrganicFarmData
{
    public class PersonAccess : IPerson
    {
        private ShopContext _shopContext;
        public PersonAccess(ShopContext shopcontext)
        {
            _shopContext = shopcontext;
        }

        public User AddPerson(User person)
        {
            _shopContext.Person.Add(person);
            _shopContext.SaveChanges();
            return person;
        }

        public void DeletePerson(User person)
        {

            _shopContext.Person.Remove(person);
            _shopContext.SaveChanges();
        }

        public User EditPerson(User person)
        {
            var per = getPerson(person.PersonId);
            per.PersonName = person.PersonName;
            per.Ppassword = person.Ppassword;
            per.City = person.City;
            per.EmailId = person.EmailId;
            per.RoleId = person.RoleId;

            _shopContext.Person.Update(per);
            _shopContext.SaveChanges();

            return per;
        }

        public List<User> getPerson()
        {
            return _shopContext.Person.ToList();
        }

        public User getPerson(int id)
        {
            return _shopContext.Person.FirstOrDefault(r => r.PersonId == id);
        }
    }
}

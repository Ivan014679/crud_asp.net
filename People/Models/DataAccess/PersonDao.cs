using People.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace People.Models.DataAccess
{
    public class PersonDao
    {
        public void Create(PersonModel p)
        {
            using (var context = new PersonEntities())
            {
                Person pe = new Person();
                pe.Name = p.Name;
                pe.Gender = p.Gender;
                pe.Phone = p.Phone;

                context.Person.Add(pe);
                context.SaveChanges();
            }
        }

        public List<PersonModel> Consult()
        {
            List<PersonModel> peoplelist = new List<PersonModel>();
            using (var context = new PersonEntities())
            {
                var query = (from d in context.Person select d).ToList();
                foreach (var item in query)
                {
                    PersonModel p = new PersonModel();
                    p.Id = item.Id;
                    p.Name = item.Name;
                    p.Gender = item.Gender;
                    p.Phone = item.Phone;

                    peoplelist.Add(p);
                }
            }
            return peoplelist;
        }

        public PersonModel ConsultOne(decimal id)
        {
            using (var context = new PersonEntities())
            {
                PersonModel person = new PersonModel();
                var record = (from d in context.Person select d).Where(d => d.Id.Equals(id)).FirstOrDefault();
                person.Id = record.Id;
                person.Name = record.Name;
                person.Gender = record.Gender;
                person.Phone = record.Phone;
                return person;
            }
        }

        public void Update(PersonModel p)
        {
            using (var context = new PersonEntities())
            {
                var query = (from d in context.Person select d).Where(d => d.Id.Equals(p.Id)).FirstOrDefault();
                query.Name = p.Name;
                query.Gender = p.Gender;
                query.Phone = p.Phone;
                context.SaveChanges();
            }
        }

        public void Delete(decimal id)
        {
            using (var context = new PersonEntities())
            {
                var record = (from d in context.Person select d).Where(d => d.Id.Equals(id)).FirstOrDefault();
                context.Person.Remove(record);
                context.SaveChanges();
            }
        }
    }
}
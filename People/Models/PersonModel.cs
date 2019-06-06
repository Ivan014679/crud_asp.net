using People.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace People.Models
{
    public class PersonModel
    {
        public decimal Id { get; set; }

        [Display(Name = "Full name")]
        [StringLength(maximumLength: 100, MinimumLength = 1)]
        public string Name { get; set; }

        [Display(Name = "Gender")]
        [StringLength(maximumLength: 20, MinimumLength = 1)]
        public string Gender { get; set; }

        [Display(Name = "Phone")]
        [StringLength(maximumLength: 10, MinimumLength = 1)]
        public string Phone { get; set; }

        public List<PersonModel> List { get; set; }

        public void Create()
        {
            PersonDao pdao = new PersonDao();
            pdao.Create(this);
        }

        public List<PersonModel> Consult()
        {
            PersonDao pdao = new PersonDao();
            return pdao.Consult();
        }

        public PersonModel ConsultOne(decimal id)
        {
            PersonDao pdao = new PersonDao();
            return pdao.ConsultOne(id);
        }

        public void Update()
        {
            PersonDao pdao = new PersonDao();
            pdao.Update(this);
        }

        public void Delete(decimal id)
        {
            PersonDao pdao = new PersonDao();
            pdao.Delete(id);
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScalabiltyHomework.Contracts.Entities.Read
{
    public class HeroRead
    {
        public HeroRead()
        {
            PromotionDate = DateTime.Now;
        }

        public HeroRead(int id, string comment)
        {
            PersonId = id;
            Comment = comment;
        }

        //public HeroRead(Person person, string comment)
        //{
        //    Person = person;
        //    PersonId = person.Id;
        //    Comment = comment;
        //}

        public HeroRead(PersonRead person, string comment)
        {
            Person = person;
            PersonId = person.Id;
            PersonWriteId = person.WriteId;
            Comment = comment;
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public int PersonWriteId { get; set; }
        [Required]
        public string Comment { get; set; }
        public DateTime PromotionDate { get; set; }

        [ForeignKey("PersonId")]
        public virtual PersonRead Person { get; set; }
    }
}
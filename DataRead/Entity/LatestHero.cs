using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScalabiltyHomework.Data.Entity
{
    public class LatestHero
    {
        public LatestHero()
        {
            PromotionDate = DateTime.Now;
        }

        public LatestHero(Hero hero)
        {
            PersonId = hero.PersonId;
            PromotionDate = hero.PromotionDate;            
        }

        public LatestHero(Person person, string comment):base()
        {
            PersonId = person.Id;
            PersonName = person.Name;
            PersonPicture = person.Picture;
            PersonGender = person.Gender; 
            Comment = comment;
        }

        public LatestHero(Person person, Hero hero)
        {
            PersonId = person.Id;
            PersonName = person.Name;
            PersonPicture = person.Picture;
            PersonGender = person.Gender;
            
            Comment = hero.Comment;
            PromotionDate = hero.PromotionDate;
        }
        
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonPicture { get; set; }
        public Gender PersonGender { get; set; }        
        public string Comment { get; set; }
        public DateTime PromotionDate { get; set; }
    }
}
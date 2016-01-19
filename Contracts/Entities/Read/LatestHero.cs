using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScalabiltyHomework.Contracts.Entities.Read
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

        public LatestHero(PersonRead person, string comment)
        {
            MapPropertiesFromPerson(person);
            Comment = comment;
        }

        public LatestHero(PersonRead person, HeroRead hero)
        {
            MapPropertiesFromPerson(person);
            
            Comment = hero.Comment;
            PromotionDate = hero.PromotionDate;
        }

        private void MapPropertiesFromPerson(PersonRead person)
        {
            PersonId = person.Id;
            PersonName = person.Name;
            PersonPicture = person.Picture;
            PersonGender = person.Gender;
        }
        
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonPicture { get; set; }
        public Gender PersonGender { get; set; }        
        public string Comment { get; set; }
        public DateTime PromotionDate { get; set; }

        public string GetPicture()
        {
            var imageFile = !string.IsNullOrEmpty(PersonPicture)
                ? PersonPicture
                : PersonGender == Gender.Man ? "man.png" : "woman.png";

            return string.Format("/content/people-images/{0}", imageFile);
        }
    }
}
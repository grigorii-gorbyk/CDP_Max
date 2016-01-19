using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScalabiltyHomework.Contracts.Entities.Read
{
    public class PersonPromotionsCount
    {
        public PersonPromotionsCount()
        {
        }

        public PersonPromotionsCount(Hero hero)
        {
            PersonId = hero.PersonId;
        }

        public PersonPromotionsCount(PersonRead person)
        {
            MapPropertiesFromPerson(person);
        }

        private void MapPropertiesFromPerson(PersonRead person)
        {
            PersonId = person.Id;
            PersonName = person.Name;
            PersonPicture = person.Picture;
            PersonGender = person.Gender;

            Count = 1;
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonPicture { get; set; }
        public Gender PersonGender { get; set; }
        public int Count { get; set; }
        
        public string GetPicture()
        {
            var imageFile = !string.IsNullOrEmpty(PersonPicture)
                ? PersonPicture
                : PersonGender == Gender.Man ? "man.png" : "woman.png";

            return string.Format("/content/people-images/{0}", imageFile);
        }
    }
}
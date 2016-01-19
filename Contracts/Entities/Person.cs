﻿namespace ScalabiltyHomework.Contracts.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public Gender Gender { get; set; }

        public string GetPicture()
        {
            var imageFile = !string.IsNullOrEmpty(Picture)
                ? Picture
                : Gender == Gender.Man ? "man.png" : "woman.png";

            return string.Format("/content/people-images/{0}", imageFile);
        }

        public string GetPictureFile()
        {
            var imageFile = !string.IsNullOrEmpty(Picture)
                ? Picture
                : Gender == Gender.Man ? "man.png" : "woman.png";

            return imageFile;
        }
    }

    public enum Gender 
    {
        Man,
        Woman
    }
}
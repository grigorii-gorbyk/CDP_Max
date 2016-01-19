namespace ScalabiltyHomework.Contracts.Entities.Read
{
    public class PersonRead
    {
        public int Id { get; set; }
        public int WriteId { get; set; }
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
    }
}
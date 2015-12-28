using ScalabiltyHomework.Data.Entity;

namespace ScalabiltyHomework.Frontend.Controllers.ViewModels
{
    public class HeroView
    {
        //public int Id { get; private set; }
        public int PersonId { get; private set; }
        public string PersonName { get; private set; }
        public string PersonPicture { get; private set; }
        public int VotesCount { get; private set; }
    }
}
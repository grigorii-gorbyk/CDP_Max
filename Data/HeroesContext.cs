using System.Data.Entity;

namespace ScalabiltyHomework.Data
{
    public class HeroesContext : DbContext
    {
        public HeroesContext() : base("name=HeroesContext")
        {
        }

        public DbSet<Entity.Person> People { get; set; }
        public DbSet<Entity.Hero> Heroes { get; set; }
    }
}

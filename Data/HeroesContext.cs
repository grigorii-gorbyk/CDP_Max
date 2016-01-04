using System.Data.Entity;
using ScalabiltyHomework.Contracts.Entities;

namespace ScalabiltyHomework.Data
{
    public class HeroesContext : DbContext
    {
        public HeroesContext() : base("name=HeroesContext")
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Hero> Heroes { get; set; }
    }
}

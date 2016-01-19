using System.Data.Entity;
using ScalabiltyHomework.Contracts.Entities.Read;

namespace ScalabiltyHomework.Data
{
    public class HeroesReadContext : DbContext
    {
        public HeroesReadContext() : base("name=HeroesContext")// the same database
        {
        }

        public DbSet<PersonPromotionsCount> Promotions { get; set; }
        public DbSet<LatestHero> LatestHeroes { get; set; }
        public DbSet<HeroRead> Heroes { get; set; }
        public DbSet<PersonRead> Persons { get; set; }
    }   
}

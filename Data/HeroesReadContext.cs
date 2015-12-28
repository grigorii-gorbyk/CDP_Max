using System.Data.Entity;

namespace ScalabiltyHomework.Data
{
    public class HeroesReadContext : DbContext
    {
        public HeroesReadContext() : base("name=HeroesContext")// the same database
        {
        }

        public DbSet<Entity.PersonPromotionsCount> Promotions { get; set; }
        public DbSet<Entity.LatestHero> LatestHeroes { get; set; }
        public DbSet<Entity.HeroRead> Heroes { get; set; }
        public DbSet<Entity.PersonRead> Persons { get; set; }
    }   
}

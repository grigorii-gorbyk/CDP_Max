using System.Data.Entity.Migrations;
using ScalabiltyHomework.Data.Entity;
using ScalabiltyHomework.Contracts.Entities;

namespace ScalabiltyHomework.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<HeroesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ScalabiltyHomework.Data.HeroesContext";
        }

        protected override void Seed(HeroesContext context)
        {
            context.People.AddOrUpdate(
                p => p.Name,
                    new Person { Name = "Alina Dolhova", Gender = Gender.Woman },
                    new Person { Name = "Anatolii Matvieievskyi", Gender = Gender.Man },
                    new Person { Name = "Andrii Savinov", Gender = Gender.Man },
                    new Person { Name = "Anton Demchenko", Gender = Gender.Man },
                    new Person { Name = "Denys Poliakov", Gender = Gender.Man },
                    new Person { Name = "Dmytro Mykhailov", Gender = Gender.Man },
                    new Person { Name = "Evgeniy Onopko", Gender = Gender.Man },
                    new Person { Name = "Grygorii Gorbyk", Gender = Gender.Man },
                    new Person { Name = "Illia Sheverdin", Gender = Gender.Man },
                    new Person { Name = "Kostiantyn Lazurenko", Gender = Gender.Man },
                    new Person { Name = "Maksim Soldatenko", Gender = Gender.Man },
                    new Person { Name = "Maryna Degtyar", Gender = Gender.Woman },
                    new Person { Name = "Mykhailo Soroka", Gender = Gender.Man },
                    new Person { Name = "Roman Golovchenko", Gender = Gender.Man },
                    new Person { Name = "Sergey Prokofiev", Gender = Gender.Man },
                    new Person { Name = "Sergey Sotnikov", Gender = Gender.Man },
                    new Person { Name = "Sergey Tischenko", Gender = Gender.Man },
                    new Person { Name = "Sergiy Parkhomenko", Gender = Gender.Man },
                    new Person { Name = "Vitalii Kosenko", Gender = Gender.Man },
                    new Person { Name = "Volodymyr Osmak", Gender = Gender.Man },
                    new Person { Name = "Yevhenii Havryliuk", Gender = Gender.Man },
                    new Person { Name = "Yevhenii Lomov", Gender = Gender.Man }
                );

        }
    }
}

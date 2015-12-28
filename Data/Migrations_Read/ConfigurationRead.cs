using System.Data.Entity.Migrations;
using ScalabiltyHomework.Data.Entity;

namespace ScalabiltyHomework.Data.Migrations_Read
{
    public sealed class ConfigurationRead : DbMigrationsConfiguration<HeroesReadContext>
    {
        //ScalabiltyHomework.Data.Migrations.ConfigurationRead
        public ConfigurationRead()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ScalabiltyHomework.Data.HeroesReadContext";
            MigrationsDirectory = @"Migrations_Read";
        }

        protected override void Seed(HeroesReadContext context)
        {
            context.Persons.AddOrUpdate(
                p => p.Name,
                    new PersonRead { Name = "Alina Dolhova", Gender = Gender.Woman},
                    new PersonRead { Name = "Anatolii Matvieievskyi", Gender = Gender.Man },
                    new PersonRead { Name = "Andrii Savinov", Gender = Gender.Man },
                    new PersonRead { Name = "Anton Demchenko", Gender = Gender.Man },
                    new PersonRead { Name = "Denys Poliakov", Gender = Gender.Man },
                    new PersonRead { Name = "Dmytro Mykhailov", Gender = Gender.Man },
                    new PersonRead { Name = "Evgeniy Onopko", Gender = Gender.Man },
                    new PersonRead { Name = "Grygorii Gorbyk", Gender = Gender.Man },
                    new PersonRead { Name = "Illia Sheverdin", Gender = Gender.Man },
                    new PersonRead { Name = "Kostiantyn Lazurenko", Gender = Gender.Man },
                    new PersonRead { Name = "Maksim Soldatenko", Gender = Gender.Man },
                    new PersonRead { Name = "Maryna Degtyar", Gender = Gender.Woman },
                    new PersonRead { Name = "Mykhailo Soroka", Gender = Gender.Man },
                    new PersonRead { Name = "Roman Golovchenko", Gender = Gender.Man },
                    new PersonRead { Name = "Sergey Prokofiev", Gender = Gender.Man },
                    new PersonRead { Name = "Sergey Sotnikov", Gender = Gender.Man },
                    new PersonRead { Name = "Sergey Tischenko", Gender = Gender.Man },
                    new PersonRead { Name = "Sergiy Parkhomenko", Gender = Gender.Man },
                    new PersonRead { Name = "Vitalii Kosenko", Gender = Gender.Man },
                    new PersonRead { Name = "Volodymyr Osmak", Gender = Gender.Man },
                    new PersonRead { Name = "Yevhenii Havryliuk", Gender = Gender.Man },
                    new PersonRead { Name = "Yevhenii Lomov", Gender = Gender.Man }
                );

        }
    }
}

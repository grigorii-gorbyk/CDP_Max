using System.Web;
using System.Web.Optimization;
using AutoMapper;
//using ScalabiltyHomework.Data.Entity;
using ScalabiltyHomework.Frontend.Controllers.ViewModels;
using ScalabiltyHomework.Contracts.Entities;
using ScalabiltyHomework.Contracts.ReadModels;
using ScalabiltyHomework.Contracts.Entities.Read;


namespace Frontend
{
    public class MapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<PersonRead, Person>()
                    .ForMember(x => x.Id, y => y.MapFrom(z => z.WriteId));
                cfg.CreateMap<Person, PersonRead>()
                    .ForMember(x => x.WriteId, y => y.MapFrom(z => z.Id))
                    .ForMember(x => x.Picture, y => y.MapFrom(z => z.GetPictureFile()));

                cfg.CreateMap<Hero, HeroRead>()
                    .ForMember(x => x.PersonWriteId, y => y.MapFrom(z => z.PersonId));

                cfg.CreateMap<HeroRead, Hero>()
                    .ForMember(x => x.PersonId, y => y.MapFrom(z => z.PersonWriteId));

                cfg.CreateMap<PersonPromotionsCount, HeroView>()
                    .ForMember(x => x.VotesCount, y => y.MapFrom(z => z.Count))
                    .ForMember(x => x.PersonPicture, y => y.MapFrom(z => z.GetPicture()));
            });
        }
    }
}

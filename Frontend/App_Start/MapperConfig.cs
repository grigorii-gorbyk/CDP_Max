using System.Web;
using System.Web.Optimization;
using AutoMapper;
using ScalabiltyHomework.Data.Entity;

namespace Frontend
{
    public class MapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(cfg=>{
                cfg.CreateMap<Hero, HeroRead>();
            });
        }
    }
}

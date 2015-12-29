using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScalabiltyHomework.Frontend.Caching
{
    public enum CacheKey
    {
        None = 0,
        //PeoplesController
        AllPeople = 1001,
        //HeroseController
        AllHeroes = 2001,
        LatestHeroes = 2002,
        TopHeroes = 2003,


    }
}
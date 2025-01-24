using AutoMapper.Internal;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Mapper.AutoMapper
{
    public class Mapper : Application.Interfaces.AutoMapper.IMapper
    {
        public static List<TypePair> typePairs = new();
        private IMapper MapperContainer;

        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
        {
            Config<TDestination,TSource>(5,ignore);

            return MapperContainer.Map<TSource, TDestination>(source);
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> sources, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);

            return MapperContainer.Map<IList<TSource>, IList<TDestination>>(sources);
        }

        public TDestination Map<TDestination, TSource>(object source, string? ignore = null)
        {
            Config<TDestination, object>(5, ignore);

            return MapperContainer.Map<TDestination>(source);
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<object> sources, string? ignore = null)
        {
            Config<TDestination, IList<object>>(5, ignore);

            return MapperContainer.Map < IList<TDestination>>(sources);
        }

        protected void Config<TDestination, TSource>(int depth = 5, string? ignore = null)
        {
            TypePair typePair = new TypePair(typeof(TDestination), typeof(TSource));

            if (typePairs.Any(a => a.DestinationType == typePair.DestinationType
                               && a.SourceType == typePair.SourceType) && ignore is null) 
            return;

            typePairs.Add(typePair);

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var item in typePairs)
                {
                    if(ignore is not null) cfg.CreateMap(item.SourceType, item.DestinationType)
                        .MaxDepth(depth).ForMember(ignore, x=> x.Ignore()).ReverseMap();
                    else
                        cfg.CreateMap(item.SourceType, item.DestinationType)
                       .MaxDepth(depth).ReverseMap();
                }
            });

            MapperContainer = config.CreateMapper();
        }
    }
}

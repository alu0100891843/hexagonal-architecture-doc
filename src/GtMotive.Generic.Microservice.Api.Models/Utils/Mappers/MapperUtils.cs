using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GtMotive.Generic.Microservice.Utils.Mappers
{
    public static class MapperUtils
    {
        public static Collection<TDestination> MapList<TSource, TDestination>(IEnumerable<TSource> sourceList, Func<TSource, TDestination> mapperFunc)
        {
            if (sourceList == null || mapperFunc == null)
            {
                return new Collection<TDestination>();
            }

            var destinationList = new Collection<TDestination>();
            foreach (var source in sourceList)
            {
                var destination = mapperFunc(source);
                destinationList.Add(destination);
            }

            return destinationList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BlockedCountriesApi.Wrappers
{
    public static class EnumerableExtensions
    {
       public static async Task<PaginatedResult<T>> ToPaginationlist<T>(this IEnumerable<T> source,int pagenumber,int pagesize)
            where T : class
        {

            if (source == null)
            {
                throw new Exception("Empty");
            }

            pagenumber = pagenumber <= 0 ? 1 : pagenumber;
            pagesize =  pagesize <= 0 ? 10 : pagesize;
             
            int count =  source.Count();
            if(count == 0)  return  PaginatedResult<T>.Success(new List<T> (),count,pagenumber,pagesize);
            var items = source.Skip((pagenumber-1)*pagesize).Take(pagesize).ToList();
            return PaginatedResult<T>.Success(items,count,pagenumber,pagesize);
        }

    }
}

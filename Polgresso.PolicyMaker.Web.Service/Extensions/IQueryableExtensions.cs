using Microsoft.EntityFrameworkCore;
using Polgresso.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Polgresso.PolicyMaker.Web.Service.Extensions
{
    public static class IQueryableExtensions
    {
        public async static Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, int? page, int recordsPerPage)
        {
            var currentPage = (page == 0) ? 1 : (page ?? 1);
            var take = recordsPerPage;
            var skip = recordsPerPage * (currentPage - 1);

            var totalRecords = source.Count();
            var list = await source.Take(take).Skip(skip).ToListAsync();

            return new PagedList<T>
            {
                TotalRecords = totalRecords,
                List = list
            };
        }
    }
}
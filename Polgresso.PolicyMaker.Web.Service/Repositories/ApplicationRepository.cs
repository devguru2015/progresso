using Polgresso.Entities;
using Polgresso.PolicyMaker.Web.Service.Db;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Polgresso.PolicyMaker.Web.Service.Extensions;

namespace Polgresso.PolicyMaker.Web.Service.Repositories
{
    public class ApplicationRepository : IRepository<Application>
    {
        private readonly PolicyMakerDbContext _context;

        private int RecordsPerPage = 10;

        public ApplicationRepository(PolicyMakerDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Application>> GetAll(int? page)
        {
            return await _context.Applications.ToPagedListAsync(page, RecordsPerPage);
        }

        public async Task AddAsync(Application entity)
        {
            await _context.Applications.AddAsync(entity);
        }

        public async Task<Application> GetSingleAsync(int id)
        {
            return await _context.Applications.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task DeleteAsync(Application entity)
        {
            _context.Applications.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Application entity)
        {
            _context.Applications.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
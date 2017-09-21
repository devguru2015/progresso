using System.Threading.Tasks;
using Polgresso.Entities;
using Polgresso.PolicyMaker.Web.Service.Db;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Polgresso.Entities.Coverages;

namespace Polgresso.PolicyMaker.Web.Service.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly PolicyMakerDbContext _context;

        public StateRepository(PolicyMakerDbContext context)
        {
            _context = context;
        }

        public async Task<IList<State>> GetAllAsync()
        {
            return await _context.States.ToListAsync();
        }

        public async Task<IList<StateCoverage>> GetStateCoveragesAsync(string abbreviation)
        {
            var stateCoverages = await _context.StateCoverages
                     .Include(sc => sc.State)
                     .Include(sc => sc.Coverage)
                     .Where(sc => sc.State.Abbreviation == abbreviation).ToListAsync();

            return stateCoverages;
        }

        public async Task<IList<StateCoverage>> GetStateCoveragesAsync(string abbreviation, string code)
        {
            var stateCoverages = await _context.StateCoverages
                     .Include(sc => sc.State)
                     .Include(sc => sc.Coverage)
                     .Where(sc => sc.State.Abbreviation == abbreviation && sc.Coverage.Code == code).ToListAsync();

            return stateCoverages;
        }
    }
}
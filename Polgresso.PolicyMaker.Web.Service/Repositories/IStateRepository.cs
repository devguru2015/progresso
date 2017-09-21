using Polgresso.Entities;
using Polgresso.Entities.Coverages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Polgresso.PolicyMaker.Web.Service.Repositories
{
    public interface IStateRepository
    {
        Task<IList<State>> GetAllAsync();

        Task<IList<StateCoverage>> GetStateCoveragesAsync(string abbreviation);

        Task<IList<StateCoverage>> GetStateCoveragesAsync(string abbreviation, string code);
    }
}
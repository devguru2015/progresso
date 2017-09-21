using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Polgresso.Dtos;
using Polgresso.Entities;
using Polgresso.Entities.Coverages;
using Polgresso.PolicyMaker.Web.Service.Filters;
using Polgresso.PolicyMaker.Web.Service.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Polgresso.PolicyMaker.Web.Service.Controllers
{
    // NOTE: Does getting coverages that belong to a state going into the states controller or the coverage
    // controller?  Use the best practices for REST APIs to determine where to place your action methods.
    // We want to acheive something like this  api/states/GA/coverage/BI because coverages belong to states.
    // There is no case where we will need to get all coverages (regardless of state), so this resource 
    // belongs in the States Controller.

    [Route("api/[controller]")]
    public class StatesController : Controller
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;

        public StatesController(IStateRepository stateRepository, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var states = await _stateRepository.GetAllAsync();

            if (states == null)
            {
                return BadRequest();
            }

            var statesDto = Mapper.Map<IList<State>, IList<StateDto>>(states);

            return Ok(statesDto);
        }

        [HttpGet]
        [GetStateCoveragesFilter]
        [Route("{abbreviation}/coverages")]
        public async Task<IActionResult> GetStateCoverages(string abbreviation)
        {
            var stateCoverages = await _stateRepository.GetStateCoveragesAsync(abbreviation);

            if (stateCoverages == null)
            {
                return NotFound();
            }

            var stateCoveragesDto = Mapper.Map<IList<StateCoverage>, IList<StateCoverageDto>>(stateCoverages);

            return Ok(stateCoveragesDto);
        }

        [HttpGet]
        [GetStateCoveragesFilter]
        [Route("{abbreviation}/coverages/{code}")]
        public async Task<IActionResult> GetStateCoverages(string abbreviation, string code)
        {
            // NOTE:  Not adding any validation for the parameter "code" because no code means the 
            // above action method will get called.
            var stateCoverages = await _stateRepository.GetStateCoveragesAsync(abbreviation, code);

            if (stateCoverages == null)
            {
                return NotFound();
            }

            var stateCoveragesDto = Mapper.Map<IList<StateCoverage>, IList<StateCoverageDto>>(stateCoverages);

            return Ok(stateCoveragesDto);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Polgresso.PolicyMaker.Web.Service.Repositories;
using Polgresso.Entities;
using System.Threading.Tasks;
using System;
using Polgresso.Dtos;
using AutoMapper;

namespace Polgresso.PolicyMaker.Web.Service.Controllers
{
    [Route("api/[controller]")]
    public class ApplicationsController : Controller
    {
        private readonly IRepository<Application> _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationsController(IRepository<Application> applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int? page)
        {
            var applications = await _applicationRepository.GetAll(page);
            
            if(applications == null)
            {
                return BadRequest();
            }
            
            return Ok(applications);
        }

        [HttpPut]
        public void Create([FromBody] ApplicationDto model)
        {



        }
    }
}
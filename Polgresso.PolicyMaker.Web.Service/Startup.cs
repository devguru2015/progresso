using AutoMapper;
using AutoMapper.EquivalencyExpression;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polgresso.Dtos;
using Polgresso.Entities;
using Polgresso.Entities.Coverages;
using Polgresso.PolicyMaker.Web.Service.Db;
using Polgresso.PolicyMaker.Web.Service.Repositories;
using Polgresso.PolicyMaker.Web.Service.Validators;
using System.IO;

namespace Polgresso.PolicyMaker.Web.Service
{
    public class Startup
    {
        private IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions()
                    .AddDbContext<PolicyMakerDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")))
                    .AddScoped<IRepository<Application>, ApplicationRepository>()
                    .AddScoped<IStateRepository, StateRepository>()
                    .AddAutoMapper(ConfigureMappers)
                    .AddMvc()
                    .AddFluentValidation(ConfigureValidators);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Need to understand why Migrations fail when this line is here.
                DbSeeder.SeedAsync(app.ApplicationServices).Wait();
            }

            app.UseMvc();            
        }

        private void ConfigureMappers(IMapperConfigurationExpression cfg)
        {
            cfg.AddCollectionMappers();

            // From Dto to Entity
            cfg.CreateMap<NamedInsuredDto, NamedInsured>();
            cfg.CreateMap<ApplicationDto, Application>();

            // From Entity to Dto
            cfg.CreateMap<State, StateDto>().EqualityComparison((s, sdto) => s.Abbreviation == sdto.Abbreviation);
            cfg.CreateMap<Coverage, CoverageDto>().EqualityComparison((c, cdto) => c.Id == cdto.Id);
            cfg.CreateMap<StateCoverage, StateCoverageDto>()
               .EqualityComparison((sc, scdto) => sc.Id == scdto.Id);
               //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               //.ForMember(dest => dest., opt => opt.MapFrom(src => src.CoverageId))
               /*
               .ForMember(dest => dest.StateAbbreviation, opt => opt.MapFrom(src => src.StateAbbreviation))
               .ForMember(dest => dest.CoverageName, opt => opt.MapFrom(src => src.Coverage.Name))
               .ForMember(dest => dest.PerPersonLimit, opt => opt.MapFrom(src => src.PerPersonLimit))
               .ForMember(dest => dest.PerAccidentLimit, opt => opt.MapFrom(src => src.PerAccidentLimit))
               .ForMember(dest => dest.Deductible, opt => opt.MapFrom(src => src.Deductible))
               .ForMember(dest => dest.IsRequired, opt => opt.MapFrom(src => src.IsRequired));
               */
        }

        private void ConfigureValidators(FluentValidationMvcConfiguration cfg)
        {
            cfg.RegisterValidatorsFromAssemblyContaining<ApplicationValidator>();
        }
    }
}
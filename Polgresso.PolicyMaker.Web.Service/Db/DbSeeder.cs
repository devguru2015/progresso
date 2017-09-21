using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Polgresso.Entities;
using Polgresso.Entities.Coverages;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Polgresso.PolicyMaker.Web.Service.Db
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            await SeedStatesAsync(serviceProvider);
            await SeedCoveragesAsync(serviceProvider);
            await SeedGeorgiaCoveragesAsync(serviceProvider);
        }

        private static async Task SeedStatesAsync(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var states = new[] {
                    new { Abbreviation = "AL", Name = "Alabama" },
                    new { Abbreviation = "AK", Name = "Alaska" },
                    new { Abbreviation = "AZ", Name = "Arizona" },
                    new { Abbreviation = "AR", Name = "Arkansas" },
                    new { Abbreviation = "CA", Name = "California" },
                    new { Abbreviation = "CO", Name = "Colorado" },
                    new { Abbreviation = "CT", Name = "Connecticut" },
                    new { Abbreviation = "DE", Name = "Delaware" },
                    new { Abbreviation = "FL", Name = "Florida" },
                    new { Abbreviation = "GA", Name = "Georgia" },
                    new { Abbreviation = "HI", Name = "Hawaii" },
                    new { Abbreviation = "ID", Name = "Idaho" },
                    new { Abbreviation = "IL", Name = "Illinois" },
                    new { Abbreviation = "IN", Name = "Indiana" },
                    new { Abbreviation = "IA", Name = "Iowa" },
                    new { Abbreviation = "KS", Name = "Kansas" },
                    new { Abbreviation = "KY", Name = "Kentucky" },
                    new { Abbreviation = "LA", Name = "Louisiana" },
                    new { Abbreviation = "ME", Name = "Maine" },
                    new { Abbreviation = "MD", Name = "Maryland" },
                    new { Abbreviation = "MA", Name = "Massachusetts" },
                    new { Abbreviation = "MI", Name = "Michigan" },
                    new { Abbreviation = "MN", Name = "Minnesota" },
                    new { Abbreviation = "MS", Name = "Mississippi" },
                    new { Abbreviation = "MO", Name = "Missouri" },
                    new { Abbreviation = "MT", Name = "Montana" },
                    new { Abbreviation = "NE", Name = "Nebraska" },
                    new { Abbreviation = "NV", Name = "Nevada" },
                    new { Abbreviation = "NH", Name = "New Hampshire" },
                    new { Abbreviation = "NJ", Name = "New Jersey" },
                    new { Abbreviation = "NM", Name = "New Mexico" },
                    new { Abbreviation = "NY", Name = "New York" },
                    new { Abbreviation = "NC", Name = "North Carolina" },
                    new { Abbreviation = "ND", Name = "North Dakota" },
                    new { Abbreviation = "OH", Name = "Ohio" },
                    new { Abbreviation = "OK", Name = "Oklahoma" },
                    new { Abbreviation = "OR", Name = "Oregon" },
                    new { Abbreviation = "PA", Name = "Pennsylvania" },
                    new { Abbreviation = "RI", Name = "Rhode Island" },
                    new { Abbreviation = "SC", Name = "South Carolina" },
                    new { Abbreviation = "SD", Name = "South Dakota" },
                    new { Abbreviation = "TN", Name = "Tennessee" },
                    new { Abbreviation = "TX", Name = "Texas" },
                    new { Abbreviation = "UT", Name = "Utah" },
                    new { Abbreviation = "VT", Name = "Vermont" },
                    new { Abbreviation = "VA", Name = "Virginia" },
                    new { Abbreviation = "WA", Name = "Washington" },
                    new { Abbreviation = "WV", Name = "West Virginia" },
                    new { Abbreviation = "WI", Name = "Wisconsin" },
                    new { Abbreviation = "WY", Name = "Wyoming" }
                };

                var scopeServiceProvider = serviceScope.ServiceProvider;
                var context = scopeServiceProvider.GetService<PolicyMakerDbContext>();

                if (context.States.Count() == 0)
                {
                    foreach (var state in states)
                    {
                        await context.States.AddAsync(new State {
                            Abbreviation = state.Abbreviation,
                            Name = state.Name });
                    }
                }

                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedCoveragesAsync(IServiceProvider serviceProvider)
        {
            var coverages = new[] {
                new
                {
                    Code = "BI",
                    Name = "Bodily Injury",
                    Description = "Bodily Injury coverage will cover injuries to others caused by you from a collision."
                },
                new
                {
                    Code = "PD",
                    Name = "Property Damage",
                    Description = "Property Damage coverage will cover you when you damage someone else's property from a collision."
                },
                new
                {
                    Code = "COLL",
                    Name = "Collision",
                    Description = "Collision coverage will cover damages to your vehicle from a collision."
                },
                new
                {
                    Code = "COMP",
                    Name = "Comprehensive",
                    Description = "Comprehensive coverage will cover damages to your vehicle from a non-collision. " +
                                  "For example, theft, vandalism, weather, etc."
                },
                new
                {
                    Code = "UMBI",
                    Name = "Uninsured Motorist Bodily Injury",
                    Description = "Uninsured Motorist Bodily Injury will cover your (and your passengers) injuries caused by an uninsured driver."
                },
                new
                {
                    Code = "UMPD",
                    Name = "Uninsured Motorist Property Damage",
                    Description = "Uninsured Motorist Property Damage will cover damages to your vehicle caused by an uninsured driver."
                }
            };

            using (var serviceScope = serviceProvider.CreateScope())
            {
                var scopeServiceProvider = serviceScope.ServiceProvider;
                var context = scopeServiceProvider.GetService<PolicyMakerDbContext>();

                if (context.Coverage.Count() == 0)
                {
                    foreach (var coverage in coverages)
                    {
                        await context.Coverage.AddAsync(new Coverage
                        {
                            Code = coverage.Code,
                            Name = coverage.Name,
                            Description = coverage.Description
                        });
                    }

                    await context.SaveChangesAsync();
                }
            }
        }

        private static async Task SeedGeorgiaCoveragesAsync(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var scopeServiceProvider = serviceScope.ServiceProvider;
                var context = scopeServiceProvider.GetService<PolicyMakerDbContext>();

                var stateOfGeorgia = await context.States.Include(s => s.StateCoverages).SingleOrDefaultAsync(s => s.Abbreviation == "GA");

                if (stateOfGeorgia != null && stateOfGeorgia.StateCoverages.Count(sc => sc.StateAbbreviation == stateOfGeorgia.Abbreviation) == 0)
                {
                    var bodilyInjury = await context.Coverage.SingleOrDefaultAsync(c => c.Code == "BI");
                    var propertyDamage = await context.Coverage.SingleOrDefaultAsync(c => c.Code == "PD");
                    var collision = await context.Coverage.SingleOrDefaultAsync(c => c.Code == "COLL");
                    var comprehensive = await context.Coverage.SingleOrDefaultAsync(c => c.Code == "COMP");
                    var uninsuredMotoristBodilyInjury = await context.Coverage.SingleOrDefaultAsync(c => c.Code == "UMBI");
                    var uninsuredMotoristPropertyDamage = await context.Coverage.SingleOrDefaultAsync(c => c.Code == "UMPD");

                    // Body Injury
                    if (bodilyInjury != null)
                    {
                        await context.StateCoverages.AddAsync(new StateCoverage
                        {
                            StateAbbreviation = stateOfGeorgia.Abbreviation,
                            CoverageId = bodilyInjury.Id,
                            PerPersonLimit = 25000.00M,
                            PerAccidentLimit = 50000.00M,
                            IsRequired = true
                        });
                        await context.StateCoverages.AddAsync(new StateCoverage
                        {
                            StateAbbreviation = stateOfGeorgia.Abbreviation,
                            CoverageId = bodilyInjury.Id,
                            PerPersonLimit = 50000.00M,
                            PerAccidentLimit = 100000.00M,
                            IsRequired = false
                        });
                        await context.StateCoverages.AddAsync(new StateCoverage
                        {
                            StateAbbreviation = stateOfGeorgia.Abbreviation,
                            CoverageId = bodilyInjury.Id,
                            PerPersonLimit = 100000.00M,
                            PerAccidentLimit = 300000.00M,
                            IsRequired = false
                        });
                    }

                    // Propety Damage
                    if (propertyDamage != null)
                    {
                        await context.StateCoverages.AddAsync(new StateCoverage
                        {
                            StateAbbreviation = stateOfGeorgia.Abbreviation,
                            CoverageId = propertyDamage.Id,
                            PerAccidentLimit = 25000.00M,
                            IsRequired = true
                        });

                        await context.StateCoverages.AddAsync(new StateCoverage
                        {
                            StateAbbreviation = stateOfGeorgia.Abbreviation,
                            CoverageId = propertyDamage.Id,
                            PerAccidentLimit = 50000.00M,
                            IsRequired = false
                        });
                    }

                    // Collision
                    if (collision != null)
                    {
                        await context.StateCoverages.AddAsync(new StateCoverage
                        {
                            StateAbbreviation = stateOfGeorgia.Abbreviation,
                            CoverageId = collision.Id,
                            Deductible = 500.00M,
                            IsRequired = false
                        });
                    }

                    // Comprehensive
                    if (comprehensive != null)
                    {
                        await context.StateCoverages.AddAsync(new StateCoverage
                        {
                            StateAbbreviation = stateOfGeorgia.Abbreviation,
                            CoverageId = comprehensive.Id,
                            Deductible = 100.00M,
                            IsRequired = false
                        });
                    }

                    // Uninsured Motorist Bodily Injury
                    if (uninsuredMotoristBodilyInjury != null)
                    {
                        await context.StateCoverages.AddAsync(new StateCoverage
                        {
                            StateAbbreviation = stateOfGeorgia.Abbreviation,
                            CoverageId = uninsuredMotoristBodilyInjury.Id,
                            PerPersonLimit = 25000.00M,
                            PerAccidentLimit = 50000.00M,
                            IsRequired = false
                        });
                        await context.StateCoverages.AddAsync(new StateCoverage
                        {
                            StateAbbreviation = stateOfGeorgia.Abbreviation,
                            CoverageId = uninsuredMotoristBodilyInjury.Id,
                            PerPersonLimit = 50000.00M,
                            PerAccidentLimit = 100000.00M,
                            IsRequired = false
                        });
                        await context.StateCoverages.AddAsync(new StateCoverage
                        {
                            StateAbbreviation = stateOfGeorgia.Abbreviation,
                            CoverageId = uninsuredMotoristBodilyInjury.Id,
                            PerPersonLimit = 100000.00M,
                            PerAccidentLimit = 50000.00M,
                            IsRequired = false
                        });
                    }

                    // Uninsured Motorist Property Damage
                    if (uninsuredMotoristPropertyDamage != null)
                    {
                        await context.StateCoverages.AddAsync(new StateCoverage
                        {
                            StateAbbreviation = stateOfGeorgia.Abbreviation,
                            CoverageId = uninsuredMotoristPropertyDamage.Id,
                            PerPersonLimit = 25000.00M,
                            PerAccidentLimit = 50000.00M,
                            IsRequired = false
                        });

                        await context.StateCoverages.AddAsync(new StateCoverage
                        {
                            StateAbbreviation = stateOfGeorgia.Abbreviation,
                            CoverageId = uninsuredMotoristPropertyDamage.Id,
                            PerPersonLimit = 50000.00M,
                            PerAccidentLimit = 100000.00M,
                            IsRequired = false
                        });
                    }
 
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
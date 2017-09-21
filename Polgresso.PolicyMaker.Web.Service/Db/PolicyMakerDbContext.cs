using Microsoft.EntityFrameworkCore;
using Polgresso.Entities;
using Polgresso.Entities.Coverages;
using Polgresso.Entities.Drivers;
using Polgresso.Entities.Vehicles;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polgresso.PolicyMaker.Web.Service.Db
{
    public class PolicyMakerDbContext : DbContext
    {
        public PolicyMakerDbContext(DbContextOptions<PolicyMakerDbContext> options) : base(options)
        {
        }

        public DbSet<State> States { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Violation> Violations { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Coverage> Coverage { get; set; }

        public DbSet<StateCoverage> StateCoverages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildState(modelBuilder);
            BuildApplication(modelBuilder);
            BuildNamedInsured(modelBuilder);
            BuildDriver(modelBuilder);
            BuildViolation(modelBuilder);
            BuildDriverViolation(modelBuilder);
            BuildCoverage(modelBuilder);
            BuildStateCoverage(modelBuilder);
            BuildApplicationCoverage(modelBuilder);
            BuildMake(modelBuilder);
            BuildModel(modelBuilder);
            BuildVehicle(modelBuilder);
            BuildVehicleMake(modelBuilder);
            BuildVehicleModel(modelBuilder);
        }

        #region Model Building

        private void BuildState(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>()
                        .HasKey(s => s.Abbreviation);
        }

        private void BuildApplication(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>()
                        .HasKey(a => a.Id);
            modelBuilder.Entity<Application>()
                        .HasOne(a => a.State)
                        .WithMany(s => s.Applications)
                        .HasForeignKey(a => a.StateAbbreviation);
        }

        private void BuildNamedInsured(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NamedInsured>()
                        .HasKey(ni => ni.Id); 
            modelBuilder.Entity<NamedInsured>()
                        .HasOne(ni => ni.Application)
                        .WithOne(p => p.NamedInsured);
            modelBuilder.Entity<NamedInsured>()
                        .OwnsOne(ni => ni.MailingAddress);
            modelBuilder.Entity<NamedInsured>()
                        .OwnsOne(ni => ni.PhysicalAddress);
        }

        private void BuildDriver(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>()
                        .HasKey(d => d.Id);                   
        }

        private void BuildViolation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Violation>()
                        .HasKey(v => v.Id);
        }

        private void BuildDriverViolation(ModelBuilder modelBuilder)
        {
            // Setup many-to-many relationship
            modelBuilder.Entity<DriverViolation>()
                        .HasKey(dv => new { dv.DriverId, dv.ViolationId });
            modelBuilder.Entity<DriverViolation>()
                        .HasOne(dv => dv.Driver)
                        .WithMany(d => d.DriverViolations)
                        .HasForeignKey(dv => dv.DriverId);
            modelBuilder.Entity<DriverViolation>()
                        .HasOne(dv => dv.Violation)
                        .WithMany(v => v.DriverViolations)
                        .HasForeignKey(dv => dv.ViolationId);
        }

        private void BuildCoverage(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coverage>()
                        .HasKey(c => c.Id);                          
        }

        private void BuildStateCoverage(ModelBuilder modelBuilder)
        {
            // NOTE:  Added a new primary key (StateCoverage.Id) rather than use only the combination of
            // State Id and Coverage Id because it is possible for a state to have
            // multiples of the same coverage.  However, they will have different limits or 
            // deductibles. 

            // Setup many-to-many relationship
            modelBuilder.Entity<StateCoverage>()
                        .HasKey(sc => new { sc.Id, sc.StateAbbreviation, sc.CoverageId });
            modelBuilder.Entity<StateCoverage>().Property(p => p.Id).UseSqlServerIdentityColumn();                 
            modelBuilder.Entity<StateCoverage>()
                        .HasOne(sc => sc.State)
                        .WithMany(d => d.StateCoverages)
                        .HasForeignKey(dv => dv.StateAbbreviation);
            modelBuilder.Entity<StateCoverage>()
                        .HasOne(sc => sc.Coverage)
                        .WithMany(c => c.StateCoverages)
                        .HasForeignKey(sc => sc.CoverageId);
        }

        private void BuildApplicationCoverage(ModelBuilder modelBuilder)
        {
            // Setup many-to-many relationship
            modelBuilder.Entity<ApplicationCoverage>()
                        .HasKey(ac => new { ac.ApplicationId, ac.CoverageId });
            modelBuilder.Entity<ApplicationCoverage>()
                        .HasOne(ac => ac.Application)
                        .WithMany(d => d.ApplicationCoverages)
                        .HasForeignKey(ac => ac.ApplicationId);
            modelBuilder.Entity<ApplicationCoverage>()
                        .HasOne(ac => ac.Coverage)
                        .WithMany(c => c.ApplicationCoverages)
                        .HasForeignKey(ac => ac.CoverageId);
        }

        private void BuildMake(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Make>()
                        .HasKey(ma => ma.Id);                       
        }

        private void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>()
                        .HasKey(mo => mo.Id);
            modelBuilder.Entity<Model>()
                        .HasOne(mo => mo.Make)
                        .WithMany(ma => ma.Models)
                        .HasForeignKey(mo => mo.MakeId);
        }

        private void BuildVehicle(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                        .HasKey(c => c.Id);               
        }

        private void BuildVehicleMake(ModelBuilder modelBuilder)
        {
            // Setup many-to-many relationship
            modelBuilder.Entity<VehicleMake>()
                        .HasKey(vm => new { vm.VehicleId, vm.MakeId });
            modelBuilder.Entity<VehicleMake>()
                        .HasOne(vm => vm.Vehicle)
                        .WithMany(v => v.VehicleMakes)
                        .HasForeignKey(vm => vm.VehicleId);
            modelBuilder.Entity<VehicleMake>()
                        .HasOne(vm => vm.Make)
                        .WithMany(m => m.VehicleMakes)
                        .HasForeignKey(vm => vm.MakeId);
        }

        private void BuildVehicleModel(ModelBuilder modelBuilder)
        {
            // Setup many-to-many relationship
            modelBuilder.Entity<VehicleModel>()
                        .HasKey(vm => new { vm.VehicleId, vm.ModelId });
            modelBuilder.Entity<VehicleModel>()
                        .HasOne(vm => vm.Vehicle)
                        .WithMany(v => v.VehicleModels)
                        .HasForeignKey(vm => vm.VehicleId);
            modelBuilder.Entity<VehicleModel>()
                        .HasOne(vm => vm.Model)
                        .WithMany(m => m.VehicleModels)
                        .HasForeignKey(vm => vm.ModelId);
        }

        #endregion
    }
}
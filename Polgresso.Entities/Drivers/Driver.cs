using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Polgresso.Entities.Drivers
{
    /// <summary>
    /// Represents a single driver on the application.
    /// </summary>
    public class Driver
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string LicenseNumber { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public MartialStatus MartialStatus { get; set; }

        [Required]
        public bool IsInsured { get; set; }

        public ICollection<DriverViolation> DriverViolations { get; set; }
    }
}
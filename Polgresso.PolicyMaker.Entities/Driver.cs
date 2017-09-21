using System;

namespace Polgresso.PolicyMaker.Entities
{
    public class Driver
    {
        public Guid Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime BirthDate { get; set; }

        public string LicenseNumber { get; set; }

        public Gender Gender { get; set; }

        public MartialStatus MartialStatus { get; set; }
    }
}
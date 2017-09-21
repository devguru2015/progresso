using System;

namespace Polgresso.PolicyMaker.Entities
{
    public class NamedInsured
    {
        public Guid Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime BirthDate { get; set; }

        public string LicenseNumber { get; set; }

        public Address PhysicalAddress { get; set; }

        public Address MailingAddress { get; set; }

        public string PrimaryPhoneNumber { get; set; }

        public string SecondaryPhoneNumber { get; set; }
    }
}
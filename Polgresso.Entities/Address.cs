using System.ComponentModel.DataAnnotations;

namespace Polgresso.Entities
{
    public class Address
    {
        [Required]
        public string StreetLine1 { get; set; }

        public string StreetLine2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string StateAbbreviation { get; set; }

        [Required]
        public string County { get; set; }

        [Required]
        public string PostalCode { get; set; }
    }
}
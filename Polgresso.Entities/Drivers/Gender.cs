using System.ComponentModel.DataAnnotations;

namespace Polgresso.Entities.Drivers
{
    public enum Gender
    {
        [Display(Name = "Male")]
        M,

        [Display(Name = "Female")]
        F,

        [Display(Name = "Other")]
        O
    }
}
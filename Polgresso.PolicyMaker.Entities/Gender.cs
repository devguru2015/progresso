using System.ComponentModel.DataAnnotations;

namespace Polgresso.PolicyMaker.Entities
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
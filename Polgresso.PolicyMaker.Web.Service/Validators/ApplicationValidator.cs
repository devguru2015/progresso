using FluentValidation;
using Polgresso.Dtos;

namespace Polgresso.PolicyMaker.Web.Service.Validators
{
    public class ApplicationValidator : AbstractValidator<ApplicationDto>
    {
        public ApplicationValidator()
        {
            RuleFor(x => x.ApplicationStage).NotEmpty();
            RuleFor(x => x.Id).GreaterThan(0)
                              .When(a => a.ApplicationStage == ApplicationStage.Drivers
                                      || a.ApplicationStage == ApplicationStage.Vehicles
                                      || a.ApplicationStage == ApplicationStage.Coverages
                                      || a.ApplicationStage == ApplicationStage.Preview);

        }
    }
}
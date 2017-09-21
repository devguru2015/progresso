using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Polgresso.PolicyMaker.Web.Service.Filters
{
    public class GetStateCoveragesFilterAttribute : ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            const string AbbreviationKey = "abbreviation";
            const int StateAbbreviationLength = 2;

            var routeValues = context.RouteData.Values;

            if (routeValues == null)
            {
                context.ModelState.AddModelError(AbbreviationKey, "No parameters are defined.");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }

            if (routeValues[AbbreviationKey] == null)
            {
                context.ModelState.AddModelError(AbbreviationKey, "Abbreviation parameter not found.");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }

            var abbreviation = routeValues[AbbreviationKey].ToString();

            if (string.IsNullOrEmpty(abbreviation))
            {
                context.ModelState.AddModelError(AbbreviationKey, "State abbreviation is required.");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }

            if (abbreviation.Length < StateAbbreviationLength || abbreviation.Length > StateAbbreviationLength)
            {
                context.ModelState.AddModelError(AbbreviationKey, "State abbreviation length must be two characters long.");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
   
            return base.OnActionExecutionAsync(context, next);
        }
    }
}
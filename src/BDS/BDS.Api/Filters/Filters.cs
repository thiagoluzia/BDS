using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BDS.Api.Filters
{
    public class Filters : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var mensagemErro = context.ModelState
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(er =>  er.ErrorMessage)
                    .ToList();

                context.Result = new BadRequestObjectResult(mensagemErro);
            }
        }
    }
}

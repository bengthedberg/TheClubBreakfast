using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TheClubBreakfast.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        // If all errors are validation errors, return a 422 
        if (errors.All(e => e.Type == ErrorType.Validation))
        {
            var modelStateDictionary = new ModelStateDictionary();
            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(error.Code, error.Description);
            }
            return ValidationProblem(modelStateDictionary);
        }

        // If any errors are unexpected, return a 500. 
        // Ignoring any other errors.
        if (errors.Any(e => e.Type == ErrorType.Unexpected))
        {
            return Problem();
        }

        var statusCode = errors.First().Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };
        return Problem(statusCode: statusCode, title: errors.First().Description);
    }
    
}
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using TheClubBreakfast.Breakfasts.Services;
using TheClubBreakfast.Contracts.Breakfast;
using TheClubBreakfast.Models;

namespace TheClubBreakfast.Controllers;

public class BreakfastsController : ApiController
{
    private readonly IBreakfastService _breakfastService;
    public BreakfastsController(IBreakfastService breakfastService)
    {
        _breakfastService = breakfastService;
    }
    
    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        var breakfastCreated = Breakfast.From(request);

        if (breakfastCreated.IsError)
        {
            return Problem(breakfastCreated.Errors);
        }
        
        var breakfast = breakfastCreated.Value;
        ErrorOr<Created> result = _breakfastService.CreateBreakfast(breakfast);
        
        return result.Match(
            created => CreatedAtActionResult(breakfast),
            errors => Problem(errors));
            
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        ErrorOr<Breakfast> result = _breakfastService.GetBreakfast(id);

        return result.Match(
            breakfast => Ok(MapBreakfastResponse(breakfast)),
            errors => Problem(errors));
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        ErrorOr<Breakfast> breakfastCreated = Breakfast.From(id, request);
        
        if (breakfastCreated.IsError)
        {
            return Problem(breakfastCreated.Errors);
        }
        
        var breakfast = breakfastCreated.Value;
        ErrorOr<Upserted> result = _breakfastService.UpsertBreakfast(id, breakfast);

        // Return 201 Created if the breakfast was created, 204 NoContent if it was updated 
        return result.Match(
            upserted => upserted.Created ? CreatedAtActionResult(breakfast) : NoContent(),
            errors => Problem(errors));
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        ErrorOr<Deleted> result = _breakfastService.DeleteBreakfast(id);
        return result.Match(
            breakfast => NoContent(),
            errors => Problem(errors));
    }
    
    private static BreakfastResponse MapBreakfastResponse(Breakfast breakfast)
    {
        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet);
        return response;
    }
    
    private CreatedAtActionResult CreatedAtActionResult(Breakfast breakfast)
    {
        return CreatedAtAction(
            nameof(GetBreakfast),
            new { id = breakfast.Id },
            MapBreakfastResponse(breakfast));
    }
}
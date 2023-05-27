using TheClubBreakfast.Models;
using TheClubBreakfast.ServiceErrors;
using ErrorOr;

namespace TheClubBreakfast.Breakfasts.Services;

public class BreakfastService : IBreakfastService
{
    // Todo: Replace with database Repository implementation
    private static readonly Dictionary<Guid, Breakfast> _breakfasts = new();

    public ErrorOr<Created> CreateBreakfast(Models.Breakfast breakfast)
    {
        _breakfasts.Add(breakfast.Id, breakfast);
        return Result.Created;
    }

    public ErrorOr<Breakfast> GetBreakfast(Guid id)
    {
        if (_breakfasts.TryGetValue(id, out var breakfast))
        {
            return breakfast;
        }
        return Errors.Breakfast.NotFound;
    }

    public ErrorOr<Upserted> UpsertBreakfast(Guid id, Breakfast breakfast)
    {
        var exists = _breakfasts.ContainsKey(breakfast.Id);
        _breakfasts[breakfast.Id] = breakfast;
        
        return new Upserted() { Created = !exists };
    }

    public ErrorOr<Deleted> DeleteBreakfast(Guid id)
    {
        _breakfasts.Remove(id);
        return Result.Deleted;
    }
}
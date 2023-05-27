using TheClubBreakfast.Models;
using ErrorOr;

namespace TheClubBreakfast.Breakfasts.Services;

public interface IBreakfastService
{
    ErrorOr<Created> CreateBreakfast(Breakfast breakfast);
    ErrorOr<Breakfast> GetBreakfast(Guid id);
    ErrorOr<Upserted> UpsertBreakfast(Guid id, Breakfast breakfast);
    ErrorOr<Deleted> DeleteBreakfast(Guid id);
}

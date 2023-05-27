using ErrorOr;

namespace TheClubBreakfast.ServiceErrors;

public static class Errors
{
    public static class Breakfast
    {
        public static Error NotFound => Error.NotFound(code: "Breakfast.NotFound", description: "Breakfast not found");
        public static Error InvalidName => Error.Validation(code: "Breakfast.Name", 
            description: $"Breakfast name is invalid, must be between {Models.Breakfast.MinNameLength} and {Models.Breakfast.MaxNameLength} characters");
    }
}
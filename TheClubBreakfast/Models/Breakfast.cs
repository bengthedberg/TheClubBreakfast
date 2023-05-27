using ErrorOr;
using TheClubBreakfast.Contracts.Breakfast;
using TheClubBreakfast.ServiceErrors;

namespace TheClubBreakfast.Models;

public class Breakfast
{
    public Guid Id { get; private set; }
    
    internal const int MinNameLength = 5;
    internal const int MaxNameLength = 100;
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public DateTime LastModifiedDateTime { get; private set; }
    public List<string> Savory { get; private set; }
    public List<string> Sweet { get; private set; }
    
    private Breakfast(Guid id, 
        string name, 
        string description, 
        DateTime startDateTime, 
        DateTime endDateTime,
        DateTime lastModifiedDateTime,
        List<string> savory, 
        List<string> sweet)
    {
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Savory = savory;
        Sweet = sweet;
        LastModifiedDateTime = lastModifiedDateTime;
    }
    
    public static ErrorOr<Breakfast> From(CreateBreakfastRequest request)
    {
        ErrorOr<Breakfast> breakfastCreated = Breakfast.Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Savory,
            request.Sweet
        );
        return breakfastCreated;
    }
    
    public static ErrorOr<Breakfast> From(Guid id, UpsertBreakfastRequest request)
    {
        ErrorOr<Breakfast> breakfastCreated = Breakfast.Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Savory,
            request.Sweet,
            id
        );
        return breakfastCreated;
    }
    
    public static ErrorOr<Breakfast> Create(string name, 
        string description, 
        DateTime startDateTime, 
        DateTime endDateTime,
        List<string> savory, 
        List<string> sweet,
        Guid? id = null)
    {
        List<Error> errors = new();
        if (string.IsNullOrWhiteSpace(name) || name.Length < MinNameLength || name.Length > MaxNameLength)
        {
            errors.Add(Errors.Breakfast.InvalidName);
        }
        
        if (string.IsNullOrWhiteSpace(description))
        {
            errors.Add(Error.Validation("Breakfast.Description", "Description is required"));
        }
        
        if (errors.Any())
        {
            return errors;
        }
        
        return new Breakfast(
            id ?? Guid.NewGuid(),
            name,
            description,
            startDateTime,
            endDateTime,
            DateTime.UtcNow,
            savory,
            sweet
        );
    }
}
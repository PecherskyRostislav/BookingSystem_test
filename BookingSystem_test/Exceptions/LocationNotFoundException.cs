namespace API.Exceptions;

public class LocationNotFoundException : NotFoundException
{
    public LocationNotFoundException(Guid locationId)
        : base($"Location with the identifier {locationId} was not found.")
    {
    }
}
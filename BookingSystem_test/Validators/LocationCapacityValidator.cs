using API.DataStore.Commands;
using FluentValidation;

namespace API.Validators;

public class LocationCapacityValidator : AbstractValidator<AddBookingCommand>
{
    public LocationCapacityValidator()
    {
    }
}

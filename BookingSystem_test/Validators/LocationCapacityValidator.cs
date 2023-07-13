using API.DataStore.Commands;
using FluentValidation;

namespace API.Validators;

public class LocationCapacityValidator : AbstractValidator<AddBookingCommand>
{
    public LocationCapacityValidator()
    {
        RuleFor(x => x.Booking.Date).NotEmpty();
        RuleFor(x => x.Booking.LocationId).NotEmpty();
        RuleFor(x => x.Booking.LocationId).IsInEnum();
    }
}

using Reserving.Application.Abstractions.Messaging;

namespace Reserving.Application.Bookings.GetBooking;

public record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;
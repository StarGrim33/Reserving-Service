using Reserving.Domain.Abstractions;

namespace Reserving.Domain.Bookings.Events;

public sealed record BookingCancelledDomainEvent(Guid BookingId) : IDomainEvent;
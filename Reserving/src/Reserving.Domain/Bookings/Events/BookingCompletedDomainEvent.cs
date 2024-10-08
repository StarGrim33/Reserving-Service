using Reserving.Domain.Abstractions;

namespace Reserving.Domain.Bookings.Events;

public sealed record BookingCompletedDomainEvent(Guid BookingId) : IDomainEvent;
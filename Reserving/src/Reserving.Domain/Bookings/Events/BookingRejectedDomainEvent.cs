using Reserving.Domain.Abstractions;

namespace Reserving.Domain.Bookings.Events;

public sealed record BookingRejectedDomainEvent(Guid BookingId) : IDomainEvent;
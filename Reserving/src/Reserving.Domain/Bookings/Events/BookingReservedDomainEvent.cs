using Reserving.Domain.Abstractions;

namespace Reserving.Domain.Bookings.Events;

public record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;
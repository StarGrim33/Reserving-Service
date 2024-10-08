using Reserving.Domain.Abstractions;

namespace Reserving.Domain.Bookings.Events;

public sealed record BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;
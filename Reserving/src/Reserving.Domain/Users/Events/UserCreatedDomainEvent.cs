using Reserving.Domain.Abstractions;

namespace Reserving.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
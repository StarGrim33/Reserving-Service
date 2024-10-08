using Reserving.Application.Abstractions.Messaging;

namespace Reserving.Application.Apartments.SearchApartmentsQuery;

public record SearchApartmentsQuery(
    DateOnly StartDate, 
    DateOnly EndDate) 
    : IQuery<IReadOnlyList<ApartmentResponse>>;
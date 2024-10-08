﻿using Reserving.Application.Abstractions.Messaging;

namespace Reserving.Application.Bookings.ReserveBooking;

public record ReserveBookingCommand(
    Guid ApartmentId,
    Guid UserId,
    DateOnly StartDate,
    DateOnly EndDate) 
    : ICommand<Guid>;
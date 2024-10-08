﻿using Dapper;
using Reserving.Application.Abstractions.Data;
using Reserving.Application.Abstractions.Messaging;
using Reserving.Domain.Abstractions;

namespace Reserving.Application.Bookings.GetBooking;

internal sealed class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, BookingResponse>
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public GetBookingQueryHandler(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        const string sql = """
                           SELECT
                               id AS Id,
                               apartment_id AS ApartmentId,
                               user_id AS UserId,
                               status AS Status,
                               price_for_period_amount AS PriceAmount,
                               price_for_period_currency AS PriceCurrency,
                               cleaning_fee_amount AS CleaningFeeAmount,
                               cleaning_fee_currency AS CleaningFeeCurrency,
                               amenities_up_charge_amount AS AmenitiesUpChargeAmount,
                               amenities_up_charge_currency AS AmenitiesUpChargeCurrency,
                               total_price_amount AS TotalPriceAmount,
                               total_price_currency AS TotalPriceCurrency,
                               duration_start AS DurationStart,
                               duration_end AS DurationEnd,
                               created_on_utc AS CreatedOnUtc
                           FROM bookings
                           WHERE id = @BookingId
                           """;

        using var connection = _connectionFactory.CreateConnection();

        var booking = await connection.QueryFirstOrDefaultAsync<BookingResponse>(
            sql,
            new
            {
                request.BookingId
            });

        return booking;
    }
}
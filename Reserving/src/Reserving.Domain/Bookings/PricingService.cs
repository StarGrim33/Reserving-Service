﻿using System.Net.Http.Headers;
using Reserving.Domain.Apartments;
using Reserving.Domain.Shared;

namespace Reserving.Domain.Bookings;

public class PricingService
{
    public PricingDetails CalculatePrice(Apartment apartment, DateRange period)
    {
        var currency = apartment.Price.Currency;

        var priceForPeriod = new Money(apartment.Price.Amount * period.LengthInDays, currency);

        var percentageUpCharge = apartment.Amenities.Sum(amenity => amenity switch
        {
            Amenity.GardenView or Amenity.MountainView => 0.05m,
            Amenity.AirConditioning => 0.01m,
            Amenity.Parking => 0.01m,
            _ => 0
        });

        var amenitiesUpCharge = Money.Zero(currency);

        if (percentageUpCharge > 0)
        {
            amenitiesUpCharge = new Money(priceForPeriod.Amount * percentageUpCharge, currency);
        }

        var totalPrice = Money.Zero();

        totalPrice += priceForPeriod;

        if (!apartment.CleaningFee.IsZero())
        {
            totalPrice += apartment.CleaningFee;
        }

        totalPrice += amenitiesUpCharge;

        return new PricingDetails(priceForPeriod, apartment.CleaningFee, amenitiesUpCharge, totalPrice);
    }
}
namespace Reserving.Domain.Bookings;

public record DateRange
{
    private DateRange()
    {
    }

    public DateOnly Start { get; init; }

    public DateOnly End { get; init; }

    public int LengthInDays => End.DayNumber - Start.DayNumber;

    public static DateRange Create(DateOnly start, DateOnly end)
    {
        const string errorMessage = "End date precedes start date";

        if (start > end)
        {
            throw new ApplicationException(errorMessage);
        }

        return new DateRange
        {
            End = end,
            Start = start
        };
    }
}
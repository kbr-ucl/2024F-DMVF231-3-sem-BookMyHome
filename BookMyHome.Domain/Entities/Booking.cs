using System.Runtime.CompilerServices;
using BookMyHome.Domain.DomainServices;
using BookMyHome.Domain.Shared;
using BookMyHome.Domain.Value;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable UnusedAutoPropertyAccessor.Global

[assembly: InternalsVisibleTo("BookMyHome.Domain.Test")]

namespace BookMyHome.Domain.Entities;

public class Booking : Entity
{
    internal Booking(Guid id, Accommodation accommodation, User user, BookingDates dates) : base(id)
    {
        Accommodation = accommodation;
        User = user;
        Dates = dates;
        TotalPrice = Accommodation.PricePrDay * Dates.DurationInDays;
    }

    public Accommodation Accommodation { get; init; }
    public User User { get; init; }
    public BookingDates Dates { get; protected set; }

    public double TotalPrice { get; protected set; }

    private bool IsBookingOverlapping(IEnumerable<Booking> otherBookings)
    {
        return otherBookings.Any(other =>
            (Dates.Departure <= other.Dates.Departure && Dates.Departure >= other.Dates.Arrival) ||
            (Dates.Arrival >= other.Dates.Arrival && Dates.Arrival <= other.Dates.Departure) ||
            (Dates.Arrival <= other.Dates.Arrival && Dates.Departure >= other.Dates.Departure));
    }

    public static Booking Create(Accommodation accommodation, User user, BookingDates dates,
        IServiceProvider services)
    {
        if (accommodation == null) throw new ArgumentNullException(nameof(accommodation));
        if (user == null) throw new ArgumentNullException(nameof(user));
        if (dates == null) throw new ArgumentNullException(nameof(dates));
        if (services == null) throw new ArgumentNullException(nameof(services));
        var domainService = services.GetService<IBookingDomainService>();
        if (domainService == null) throw new ArgumentNullException(nameof(domainService));

        var booking = new Booking(Guid.NewGuid(), accommodation, user, dates);
        if (booking.IsBookingOverlapping(domainService.OtherBookings(booking)))
            throw new InvalidOperationException("Booking overlaps with existing booking");

        return booking;
    }
}
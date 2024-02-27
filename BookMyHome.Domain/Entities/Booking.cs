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
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    internal Booking() : base(Guid.NewGuid())
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    internal Booking(Guid id, Accommodation accommodation, User user, BookingDates dates) : base(id)
    {
        Accommodation = accommodation;
        User = user;
        BookingDates = dates;
        TotalPrice = Accommodation.PricePrDay * BookingDates.DurationInDays;
    }

    public Accommodation Accommodation { get; init; }
    public User User { get; init; }
    public BookingDates BookingDates { get; protected set; }

    public double TotalPrice { get; protected set; }

    private bool IsBookingOverlapping(IEnumerable<Booking> otherBookings)
    {
        return otherBookings.Any(other =>
            (BookingDates.Departure <= other.BookingDates.Departure && BookingDates.Departure >= other.BookingDates.Arrival) ||
            (BookingDates.Arrival >= other.BookingDates.Arrival && BookingDates.Arrival <= other.BookingDates.Departure) ||
            (BookingDates.Arrival <= other.BookingDates.Arrival && BookingDates.Departure >= other.BookingDates.Departure));
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

    public void Delete()
    {
        // Delete logic
    }

    public void Update(BookingDates dates, IServiceProvider services)
    {
        if (dates == null) throw new ArgumentNullException(nameof(dates));
        if (services == null) throw new ArgumentNullException(nameof(services));
        var domainService = services.GetService<IBookingDomainService>();
        if (domainService == null) throw new ArgumentNullException(nameof(domainService));

        BookingDates = dates;
        if (IsBookingOverlapping(domainService.OtherBookings(this)))
            throw new InvalidOperationException("Booking overlaps with existing booking");
    }
}
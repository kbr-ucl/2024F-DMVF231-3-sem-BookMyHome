using BookMyHome.Domain.DomainServices;
using BookMyHome.Domain.Entities;
using BookMyHome.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure.DomainServices;

public class BookingDomainService : IBookingDomainService
{
    private readonly BookMyHomeContext _context;

    public BookingDomainService(BookMyHomeContext context)
    {
        _context = context;
    }

    IEnumerable<Booking> IBookingDomainService.OtherBookings(Booking booking)
    {
        return _context.Bookings.AsNoTracking()
            .Where(a => a.Accommodation.Id == booking.Accommodation.Id && a.Id != booking.Id).ToList();
    }

    //internal bool IsBookingOverlapping(List<Booking> otherBookings, Booking booking)
    //{
    //    return otherBookings.Any(other => booking.Dates.Arrival < other.Dates.Departure && other.Dates.Arrival < booking.Dates.Departure);
    //}
}
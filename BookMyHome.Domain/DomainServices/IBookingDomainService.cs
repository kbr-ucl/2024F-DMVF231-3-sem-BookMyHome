using BookMyHome.Domain.Entities;

namespace BookMyHome.Domain.DomainServices;

public interface IBookingDomainService
{
    IEnumerable<Booking> OtherBookings(Booking booking);
}
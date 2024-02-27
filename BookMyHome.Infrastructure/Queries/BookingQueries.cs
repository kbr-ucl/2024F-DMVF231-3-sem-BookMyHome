using BookMyHome.Application.Queries.Booking;
using BookMyHome.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure.Queries;

public class BookingQueries : IBookingQueries
{
    private readonly BookMyHomeContext _db;

    public BookingQueries(BookMyHomeContext db)
    {
        _db = db;
    }

    BookingQueryDto IBookingQueries.GetBooking(Guid id)
    {
        var result = _db.Bookings.AsNoTracking()
            .Select(b => new BookingQueryDto
            {
                Id = b.Id,
                AccommodationId = b.Accommodation.Id,
                UserId = b.User.Id,
                Arrival = b.BookingDates.Arrival,
                Departure = b.BookingDates.Departure,
                TotalPrice = b.TotalPrice,
                RowVersion = b.RowVersion
            })
            .FirstOrDefault(b => b.Id == id);

        return result ?? throw new Exception("Booking not found");
    }

    IEnumerable<BookingQueryDto> IBookingQueries.GetBookingsByAccommodation(Guid accommodationId)
    {
        var result = _db.Bookings.AsNoTracking()
            .Select(b => new BookingQueryDto
            {
                Id = b.Id,
                AccommodationId = b.Accommodation.Id,
                UserId = b.User.Id,
                Arrival = b.BookingDates.Arrival,
                Departure = b.BookingDates.Departure,
                TotalPrice = b.TotalPrice,
                RowVersion = b.RowVersion
            })
            .Where(b => b.AccommodationId == accommodationId)
            .ToList();
        return result;
    }

    IEnumerable<BookingQueryDto> IBookingQueries.GetBookingsByUser(Guid userId)
    {
        var result = _db.Bookings.AsNoTracking()
            .Select(b => new BookingQueryDto
            {
                Id = b.Id,
                AccommodationId = b.Accommodation.Id,
                UserId = b.User.Id,
                Arrival = b.BookingDates.Arrival,
                Departure = b.BookingDates.Departure,
                TotalPrice = b.TotalPrice,
                RowVersion = b.RowVersion
            })
            .Where(b => b.UserId == userId)
            .ToList();

        return result;
    }
}
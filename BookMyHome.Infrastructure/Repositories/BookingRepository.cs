using BookMyHome.Application.Repository;
using BookMyHome.Domain.Entities;
using BookMyHome.Infrastructure.Database;

namespace BookMyHome.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly BookMyHomeContext _db;

    public BookingRepository(BookMyHomeContext db)
    {
        _db = db;
    }

    void IBookingRepository.AddBooking(Booking booking)
    {
        _db.Bookings.Add(booking);
        _db.SaveChanges();
    }

    void IBookingRepository.DeleteBooking(Booking booking, byte[] rowVersion)
    {
        // https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/concurrency?view=aspnetcore-8.0#update-edit-methods
        _db.Entry(booking).Property(p => p.RowVersion).OriginalValue = rowVersion;
        _db.Bookings.Remove(booking);
    }

    Booking IBookingRepository.GetBooking(Guid id)
    {
        return _db.Bookings.Find(id) ?? throw new Exception("Booking not found");
    }

    void IBookingRepository.UpdateBooking(Booking booking, byte[] rowVersion)
    {
        // https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/concurrency?view=aspnetcore-8.0#update-edit-methods
        _db.Entry(booking).Property(p => p.RowVersion).OriginalValue = rowVersion;
        _db.SaveChanges();
    }
}
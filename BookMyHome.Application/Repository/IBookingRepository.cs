using BookMyHome.Domain.Entities;

namespace BookMyHome.Application.Repository;

public interface IBookingRepository
{
    void AddBooking(Booking booking);
    void DeleteBooking(Booking booking, byte[] rowVersion);
    Booking GetBooking(Guid id);
    void UpdateBooking(Booking booking, byte[] rowVersion);
}

public interface IAccommodationRepository
{
    Accommodation GetAccommodation(Guid accommodationId);
}

public interface IUserRepository
{
    User GetUser(Guid userId);
}
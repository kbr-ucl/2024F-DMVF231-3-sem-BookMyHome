using BookMyHome.Application.Helpers;
using BookMyHome.Application.Repository;
using BookMyHome.Domain.Value;

namespace BookMyHome.Application.Commands.Booking.Implementation;

public class BookingCommand : IBookingCommand
{
    private readonly IAccommodationRepository _accommodationRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IServiceProvider _serviceProvider;
    private readonly IUnitOfWork _uow;
    private readonly IUserRepository _userRepository;

    public BookingCommand(IUnitOfWork uow, IBookingRepository bookingRepository,
        IAccommodationRepository accommodationRepository,
        IUserRepository userRepository, IServiceProvider serviceProvider)
    {
        _uow = uow;
        _bookingRepository = bookingRepository;
        _accommodationRepository = accommodationRepository;
        _userRepository = userRepository;
        _serviceProvider = serviceProvider;
    }

    void IBookingCommand.CreateBooking(CreateBookingDto createBookingDto)
    {
        try
        {
            _uow.BeginTransaction();

            var accommodation = _accommodationRepository.GetAccommodation(createBookingDto.AccommodationId);
            if (accommodation is null) throw new Exception("Accommodation not found");
            var user = _userRepository.GetUser(createBookingDto.UserId);
            if (user is null) throw new Exception("User not found");
            var booking = Domain.Entities.Booking.Create(accommodation, user,
                new BookingDates(createBookingDto.Arrival, createBookingDto.Departure), _serviceProvider);
            _bookingRepository.AddBooking(booking);
            
            _uow.Commit();
        }
        catch (Exception e)
        {
            try
            {
                _uow.Rollback();
            }
            catch (Exception ex)
            {
                throw new Exception($"Rollback failed: {ex.Message}", e);
            }

            throw;
        }
    }

    void IBookingCommand.DeleteBooking(DeleteBookingDto deleteBookingDto)
    {
        var booking = _bookingRepository.GetBooking(deleteBookingDto.Id);
        if (booking is null) throw new Exception("Booking not found");
        booking.Delete();
        _bookingRepository.DeleteBooking(booking, deleteBookingDto.RowVersion);
    }

    void IBookingCommand.UpdateBooking(UpdateBookingDto updateBookingDto)
    {
        try
        {
            _uow.BeginTransaction();
            var booking = _bookingRepository.GetBooking(updateBookingDto.Id);
            if (booking is null) throw new Exception("Booking not found");
            booking.Update(new BookingDates(updateBookingDto.Arrival, updateBookingDto.Departure), _serviceProvider);
            _bookingRepository.UpdateBooking(booking, updateBookingDto.RowVersion);

            _uow.Commit();
        }
        catch (Exception e)
        {
            try
            {
                _uow.Rollback();
            }
            catch (Exception ex)
            {
                throw new Exception($"Rollback failed: {ex.Message}", e);
            }

            throw;
        }
    }
}
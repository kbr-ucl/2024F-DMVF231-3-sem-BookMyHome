using BookMyHome.Application.Repository;
using BookMyHome.Domain.Value;

namespace BookMyHome.Application.Commands.Booking.Implementation;

public class BookingCommand : IBookingCommand
{
    private readonly IAccommodationRepository _accommodationRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IServiceProvider _serviceProvider;
    private readonly IUserRepository _userRepository;

    public BookingCommand(IBookingRepository bookingRepository, IAccommodationRepository accommodationRepository,
        IUserRepository userRepository, IServiceProvider serviceProvider)
    {
        _bookingRepository = bookingRepository;
        _accommodationRepository = accommodationRepository;
        _userRepository = userRepository;
        _serviceProvider = serviceProvider;
    }

    void IBookingCommand.CreateBooking(CreateBookingDto createBookingDto)
    {
        var accommodation = _accommodationRepository.GetAccommodation(createBookingDto.AccommodationId);
        if (accommodation is null) throw new Exception("Accommodation not found");
        var user = _userRepository.GetUser(createBookingDto.UserId);
        if (user is null) throw new Exception("User not found");
        var booking = Domain.Entities.Booking.Create(accommodation, user,
            new BookingDates(createBookingDto.Arrival, createBookingDto.Departure), _serviceProvider);
        _bookingRepository.AddBooking(booking);
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
        var booking = _bookingRepository.GetBooking(updateBookingDto.Id);
        if (booking is null) throw new Exception("Booking not found");
        booking.Update(new BookingDates(updateBookingDto.Arrival, updateBookingDto.Departure), _serviceProvider);
        _bookingRepository.UpdateBooking(booking, updateBookingDto.RowVersion);
    }
}
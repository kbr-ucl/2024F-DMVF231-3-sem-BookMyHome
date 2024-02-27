namespace BookMyHome.Application.Commands.Booking;

public interface IBookingCommand
{
    void CreateBooking(CreateBookingDto createBookingDto);
    void UpdateBooking(UpdateBookingDto updateBookingDto);
    void DeleteBooking(DeleteBookingDto deleteBookingDto);
}

public class CreateBookingDto
{
    public Guid AccommodationId { get; set; }
    public Guid UserId { get; set; }
    public DateOnly Arrival { get; set; }
    public DateOnly Departure { get; set; }
}

public class UpdateBookingDto
{
    public Guid Id { get; set; }
    public DateOnly Arrival { get; set; }
    public DateOnly Departure { get; set; }
    public byte[] RowVersion { get; set; } = [];
}

public class DeleteBookingDto
{
    public Guid Id { get; set; }
    public byte[] RowVersion { get; set; } = [];
}
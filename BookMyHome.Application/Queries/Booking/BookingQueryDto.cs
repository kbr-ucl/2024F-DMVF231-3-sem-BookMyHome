namespace BookMyHome.Application.Queries.Booking;

public class BookingQueryDto
{
    public Guid Id { get; set; }
    public Guid AccommodationId { get; set; }
    public Guid UserId { get; set; }
    public DateOnly Arrival { get; set; }
    public DateOnly Departure { get; set; }
    public double TotalPrice { get;  set; }
    public byte[] RowVersion { get;  set; }
}
using BookMyHome.Domain.Shared;
using BookMyHome.Domain.Value;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace BookMyHome.Domain.Entities;

public class Accommodation : Entity
{
    public Accommodation(Guid id, Address address, double pricePrDay) : base(id)
    {
        Address = address;
        PricePrDay = pricePrDay;
    }

    public double PricePrDay { get; protected set; }
    public Address Address { get; protected set; }
    public List<Booking> Bookings { get; protected set; } = new();
}
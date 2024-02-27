using BookMyHome.Domain.Shared;
using BookMyHome.Domain.Value;
// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace BookMyHome.Domain.Entities;

public class Accommodation : Entity
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    internal Accommodation() : base(Guid.NewGuid())
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    public Accommodation(Guid id, Address address, double pricePrDay) : base(id)
    {
        Address = address;
        PricePrDay = pricePrDay;
    }

    public double PricePrDay { get; internal set; }
    public Address Address { get; internal set; }
    public List<Booking> Bookings { get; internal set; } = new();
}
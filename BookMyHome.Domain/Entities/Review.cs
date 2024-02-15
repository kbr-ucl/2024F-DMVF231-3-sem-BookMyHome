using BookMyHome.Domain.Shared;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace BookMyHome.Domain.Entities;

public class Review : Entity

{
    public Accommodation Accommodation{ get; init; }
    public Rating Rating { get; protected set; }
    public User User { get; init; }
    public string Comment { get; protected set; }
    public DateTime Date { get; protected set; }

    public Review(Guid id, Accommodation accommodation, Rating rating, User user, string comment) : base(id)
    {
        Accommodation = accommodation;
        Rating = rating;
        User = user;
        Comment = comment;
        Date = DateTime.Now;
    }
}
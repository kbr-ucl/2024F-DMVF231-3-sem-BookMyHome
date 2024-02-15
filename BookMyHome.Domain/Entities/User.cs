using BookMyHome.Domain.Shared;
using BookMyHome.Domain.Value;

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace BookMyHome.Domain.Entities;

public class User : Entity
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    internal User() : base(Guid.NewGuid())
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }
    public User(Guid id, EmailAddress email, Name name) : base(id)
    {
        Email = email;
        Name = name;
    }

    public Name Name { get; init; }
    public EmailAddress Email { get; init; }
}
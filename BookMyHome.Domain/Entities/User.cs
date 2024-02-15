using BookMyHome.Domain.Shared;
using BookMyHome.Domain.Value;

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace BookMyHome.Domain.Entities;

public class User : Entity
{
    public User(Guid id, EmailAddress email, Name name) : base(id)
    {
        Email = email;
        Name = name;
    }

    public Name Name { get; init; }
    public EmailAddress Email { get; init; }
}
using BookMyHome.Domain.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace BookMyHome.Infrastructure.Database;

public class BookMyHomeContext
{
    public DbSet<Booking> Books { get; set; } = null!;
}
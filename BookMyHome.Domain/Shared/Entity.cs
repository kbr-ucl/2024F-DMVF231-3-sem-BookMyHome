using System.ComponentModel.DataAnnotations;

namespace BookMyHome.Domain.Shared;

public abstract class Entity(Guid id)
{
    public Guid Id { get; init; } = id;

    [Timestamp] public byte[] RowVersion { get; private set; } = [];
}
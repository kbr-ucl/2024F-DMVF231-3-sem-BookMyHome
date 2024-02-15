// ReSharper disable UnusedAutoPropertyAccessor.Global

using BookMyHome.Domain.Shared;

namespace BookMyHome.Domain.Value;

public record EmailAddress(string Value) : RecordWithValidation
{
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Value)) throw new ArgumentException("Email address cannot be empty");

        if (!Value.Contains('@')) throw new ArgumentException("Email address is not valid");
    }
}
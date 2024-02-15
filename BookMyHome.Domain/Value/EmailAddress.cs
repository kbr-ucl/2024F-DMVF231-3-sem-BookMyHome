// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace BookMyHome.Domain.Value;

public record EmailAddress
{
    public string Value { get; }

    public EmailAddress(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Email address cannot be empty");
        }

        if (!value.Contains('@'))
        {
            throw new ArgumentException("Email address is not valid");
        }

        Value = value;
    }
}
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
namespace BookMyHome.Domain.Value;

public record Address(string Street, string City, string PostalCode, string Country);
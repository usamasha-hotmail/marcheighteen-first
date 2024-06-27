using System.Text.Json.Serialization;

namespace Contoso.Spaces.Console.Models
{
    internal record Room(
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("monthlyRate")] double MonthlyRate,
        [property: JsonPropertyName("seats")] int Seats,
        [property: JsonPropertyName("privateFacilities")] bool PrivateFacilities,
        [property: JsonPropertyName("phoneIncluded")] bool PhoneIncluded,
        [property: JsonPropertyName("windows")] bool Windows,
        [property: JsonPropertyName("corner")] bool Corner
    );
}
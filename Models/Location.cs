using System.Text.Json.Serialization;

namespace Contoso.Spaces.Console.Models
{  
    internal record Location(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("longitude")] double Longitude,
        [property: JsonPropertyName("latitude")] double Latitude,
        [property: JsonPropertyName("mailingAddress")] string MailingAddress,
        [property: JsonPropertyName("parkingIncluded")] bool ParkingIncluded,
        [property: JsonPropertyName("conferenceRoomsIncluded")] bool ConferenceRoomsIncluded,
        [property: JsonPropertyName("receptionIncluded")] bool ReceptionIncluded,
        [property: JsonPropertyName("publicAccess")] bool PublicAccess,
        [property: JsonPropertyName("lastRenovationDate")] DateTime LastRenovationDate,
        [property: JsonPropertyName("image")] string Image,
        [property: JsonPropertyName("rooms")] IReadOnlyList<Room> Rooms
    );
}
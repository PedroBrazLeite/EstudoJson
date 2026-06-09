using System.Text.Json.Serialization;
using EstudoJson.Converters;

namespace EstudoJson.Models;

public record Pessoa(
    [property: JsonPropertyName("_id")] string Id,
    [property: JsonPropertyName("guid")] Guid Guid,
    [property: JsonPropertyName("isActive")] bool IsActive,
    [property: JsonPropertyName("salary")] decimal Salary,
    [property: JsonPropertyName("age")] int Age,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("gender")] string Gender,
    [property: JsonPropertyName("registered"), JsonConverter(typeof(DateTimeConverter))] DateTime Registered,
    [property: JsonPropertyName("tags")] string[] Tags,
    [property: JsonPropertyName("friends")] Amigo[] Friends,
    [property: JsonPropertyName("favoriteFruit")] string FavoriteFruit
);


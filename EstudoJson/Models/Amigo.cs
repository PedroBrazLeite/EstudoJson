using System.Text.Json.Serialization;

public record Amigo(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name
);
using System.Text.Json.Serialization;

public class Amigo
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; }
}
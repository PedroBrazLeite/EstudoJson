using System.Text.Json.Serialization;

public class Pessoa
{
    [JsonPropertyName("_id")]
    public string Id { get; }

    [JsonPropertyName("guid")]
    public string Guid { get;}

    [JsonPropertyName("isActive")]
    public bool IsActive { get;}

    [JsonPropertyName("salary")]
    public double Salary { get;}

    [JsonPropertyName("age")]
    public int Age { get;}

    [JsonPropertyName("name")]
    public string Name { get;}

    [JsonPropertyName("gender")]
    public string Gender { get;}

    [JsonPropertyName("registered")]
    public string Registered { get;}

    [JsonPropertyName("tags")]
    public List<string> Tags { get;}

    [JsonPropertyName("friends")]
    public List<Amigo> Friends { get;}

    [JsonPropertyName("favoriteFruit")]
    public string FavoriteFruit { get;}
}
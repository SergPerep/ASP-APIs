using System.Text.Json.Serialization;

namespace MinAPI.Model
{
    public class Food
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("protein")]
        public int Protein { get; set; }
        [JsonPropertyName("carbs")]
        public int Carbs { get; set; }
        [JsonPropertyName("fat")]
        public int Fat { get; set; }
        [JsonPropertyName("fiber")]
        public int Fiber { get; set; }
        [JsonPropertyName("alcohol")]
        public int Alcohol { get; set; }
    }
}
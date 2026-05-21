using Newtonsoft.Json;

namespace MinAPI.Model
{
    public class Food
    {
        [JsonProperty("id")]
        public string Id { get; set; } = "";
        [JsonProperty("name")]
        public required string Name { get; set; }
        [JsonProperty("protein")]
        public int Protein { get; set; }
        [JsonProperty("carbs")]
        public int Carbs { get; set; }
        [JsonProperty("fat")]
        public int Fat { get; set; }
        [JsonProperty("fiber")]
        public int Fiber { get; set; }
        [JsonProperty("alcohol")]
        public int Alcohol { get; set; }
    }
}
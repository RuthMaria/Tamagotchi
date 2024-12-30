using System.Text.Json.Serialization;

namespace Tamagotchi.Model
{
    public class PokemonResult
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}

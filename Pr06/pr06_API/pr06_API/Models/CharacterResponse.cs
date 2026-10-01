using System.Text.Json.Serialization;

namespace pr06_API.Models
{
    public class CharacterResponse
    {
        [JsonPropertyName("info")]
        public Info Info { get; set; }

        [JsonPropertyName("results")]
        public List<Character> Characters { get; set; }
    }
    public class Info
    {

        [JsonPropertyName("pages")]
        public int Pages { get; set; }
    }
}

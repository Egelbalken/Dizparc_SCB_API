using System.Text.Json.Serialization;

namespace Domain
{
    public class Root
    {
        [JsonPropertyName("Root")]
        public string Title { get; set; } = String.Empty;
        public List<Variable> Variables { get; set; } = new();
    }
}
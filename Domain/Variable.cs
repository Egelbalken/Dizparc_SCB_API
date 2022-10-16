

using System.Text.Json.Serialization;

namespace Domain
{
    [Serializable]
    public class Variable
    {
        [JsonPropertyName("Variables")]
        public string Code { get; set; } = String.Empty;
        public string Text { get; set; } = String.Empty;
        public List<string> Values { get; set; } = new();
        public List<string> ValueTexts { get; set; } = new();
        public bool Elimination { get; set; }
        public bool? Time { get; set; }

    }
}
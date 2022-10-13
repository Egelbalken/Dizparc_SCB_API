using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Variable
    {
        public Guid Id { get; set; }
        public string code { get; set; }
        public string text { get; set; }
        public List<string> values { get; set; }
        public List<string> valueTexts { get; set; }
        public bool elimination { get; set; }
        public bool time { get; set; }

    }
}
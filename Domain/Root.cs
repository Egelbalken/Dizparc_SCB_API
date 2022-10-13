using System.ComponentModel.DataAnnotations;

namespace Domain
{
    [Serializable]
    public class Root
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public List<Variable> variables { get; set; }
    }
}
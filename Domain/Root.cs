using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Root
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public List<Variable> variables { get; set; }
    }
}
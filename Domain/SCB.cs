namespace Domain
{
    /// <summary>
    /// This is my class for SCB PxWeb API
    /// </summary>
    public class SCB
    {
        public Guid Id { get; set; }
        
        public string? County { get; set; }

        public int ManInCounty { get; set; }
        
        public int WomanInCounty { get; set; }
        
        public string? BirthYearOfBabies { get; set; }
        
        public int BabesTotal { get; set; }

    }
}
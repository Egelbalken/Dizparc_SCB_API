using System.Runtime.Serialization.Json;
using System.Text.Json;
using Domain;

namespace Persistence
{
    public class Seed
    {
        /// <summary>
        /// Trying to seed the database... 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task SeedData(DataContext context)
        {
        
        string sCBData = File.ReadAllText("BefolkningNy.json");

        var stat = JsonSerializer.Deserialize<List<SCB>>(sCBData);
        if(context.SCBs.Any()) return;


                var statistics = new List<SCB>
                {
                    new SCB
                    {
                        ManInCounty = 200,
                        WomanInCounty =250,
                        BabesTotal = 500,
                        BirthYearOfBabies = "2010",
                        County = "Halmstad",

                    }

                };
                await context.SCBs.AddRangeAsync(statistics);
                await context.SaveChangesAsync();

        }
    }
}


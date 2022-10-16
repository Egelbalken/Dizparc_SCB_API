using System.Text.Json;
using Domain;

namespace Persistence
{
    public class Seed
    {
        /// <summary>
        /// Used https://json2csharp.com/ 
        /// To find out how to match and create a c# class structure.
        /// Then convert the "Json" key-value pair. to c# properties.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// 
        // JsonData object
        public Root varObj;
        public static async Task SeedData(DataContext context)
        {

            /*
                A using to add fetch the Json data and convert it to C# objects.
            */

            var httpClient = new HttpClient();

            var result = await httpClient.GetAsync("http://api.scb.se/OV0104/v1/doris/en/ssd/BE/BE0101/BE0101A/BefolkningNy");

            string content = await result.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var rootObject = JsonSerializer.Deserialize<Root>(content, options);

            if (rootObject != null)
            {
                foreach (var variable in rootObject.Variables)
                {
                    /*

                    var varObj = new Variable
                    {
                        Code = variable.Code,
                        Text = variable.Text,
                        Values = variable.Values,
                        ValueTexts = variable.ValueTexts,
                        Elimination = variable.Elimination,
                        Time = variable.Time
                    };
                    */

                    var varRootObj = new Root
                    {
                        Title = rootObject.Title,
                        Variables = rootObject.Variables
                    };


                }

                await context.roots.AddRangeAsync(rootObject);
            }



            await context.SaveChangesAsync();

        }
    }
}


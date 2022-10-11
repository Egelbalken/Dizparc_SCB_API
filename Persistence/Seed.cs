using System.Runtime.Serialization.Json;
using System.Text.Json;
using Domain;
using Newtonsoft.Json;

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
        public static async Task SeedData(DataContext context)
        {
            // JsonData object
            Root data;

            using (var client = new HttpClient())
            {

                var endpoint = new Uri("http://api.scb.se/OV0104/v1/doris/en/ssd/BE/BE0101/BE0101A/BefolkningNy");

                var result = client.GetAsync(endpoint).Result;

                var json = await result.Content.ReadAsStringAsync();

                //Console.WriteLine(json);

                data = JsonConvert.DeserializeObject<Root>(json);

            }


            if (context.roots.Any()) return;

            Root root = new Root()
            {
                title = data.title,
                variables = new List<Variable>(data.variables),
            };

            await context.roots.AddRangeAsync(root);

            Variable variable = new Variable()
            {
                code = "",
                text = "",
                values = new List<string>(),
                valueTexts = new List<string>(),
                elimination = true,
                time = true,
            };
            await context.variables.AddRangeAsync(variable);

            await context.SaveChangesAsync();

        }
    }
}


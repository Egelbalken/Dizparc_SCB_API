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
        // JsonData object
        public static List<Root> dataRoot = new List<Root>();
        public static List<Variable> dataVariable = new List<Variable>();

        public static async Task SeedData(DataContext context)
        {

            using (var client = new HttpClient())
            {

                var endpoint = new Uri("http://api.scb.se/OV0104/v1/doris/en/ssd/BE/BE0101/BE0101A/BefolkningNy");

                var result = client.GetAsync(endpoint).Result;

                var json = await result.Content.ReadAsStringAsync();

                // It will throw a exeption here, can not parse whit Domain clases.                
                dataRoot = JsonConvert.DeserializeObject<List<Root>>(json);
                dataVariable = JsonConvert.DeserializeObject<List<Variable>>(json);
            }


            //if (context.roots.Any()) return;

            /* About to add a loop.
            */
            foreach (var item in dataVariable)
            {
                Variable variable = new Variable()
                {
                    code = item.code,
                    text = item.text,
                    values = new List<string>(item.values),
                    valueTexts = new List<string>(item.valueTexts),
                    elimination = item.elimination,
                    time = item.time,
                };

                foreach (var rootItem in dataRoot)
                {

                    Root root = new Root()
                    {
                        title = rootItem.title,
                        variables = new List<Variable>(rootItem.variables),
                    };

                    await context.variables.AddRangeAsync(variable);
                    await context.roots.AddRangeAsync(root);
                }
            }

            await context.SaveChangesAsync();

        }
    }
}


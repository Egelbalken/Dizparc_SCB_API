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
            Root dataRoot;
            Variable dataVariable;

            using (var client = new HttpClient())
            {

                var endpoint = new Uri("http://api.scb.se/OV0104/v1/doris/en/ssd/BE/BE0101/BE0101A/BefolkningNy");

                var result = client.GetAsync(endpoint).Result;

                var json = await result.Content.ReadAsStringAsync();

                //Console.WriteLine(json);

                dataRoot = JsonConvert.DeserializeObject<Root>(json);
                dataVariable = JsonConvert.DeserializeObject<Variable>(json);
            }


            if (context.roots.Any()) return;

            /* About to add a loop.
            foreach(var year in dataRoot)
            {

            }
            */

            Variable variable = new Variable()
            {
                code = dataVariable.code,
                text = dataVariable.text,
                values = new List<string>(dataVariable.values),
                valueTexts = new List<string>(dataVariable.valueTexts),
                elimination = dataVariable.elimination,
                time = dataVariable.time,
            };
            await context.variables.AddRangeAsync(variable);

            Root root = new Root()
            {
                title = dataRoot.title,
                variables = new List<Variable>(dataRoot.variables),
            };

            await context.roots.AddRangeAsync(root);

            await context.SaveChangesAsync();

        }
    }
}


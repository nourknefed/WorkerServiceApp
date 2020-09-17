using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SharedLibrary.Models;
using System;

namespace AzureFunctions
{
    public static class GetTempretautre

    {
        private static Random rnd = new Random();

        [FunctionName("GetTempretautre")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var data = new SharedLibrary.TempratureModel()
            {
                 Temperature = rnd.Next(20,30),
                 Humidity = rnd.Next(30,40)
                

            };


            var json = JsonConvert.SerializeObject(data);



            //log.LogInformation("C# HTTP trigger function processed a request.");

            //string name = req.Query["name"];


            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //var  data = JsonConvert.DeserializeObject<dynamic>(requestBody);
            //name = name ?? data?.Name;

            //string responseMessage = string.IsNullOrEmpty(name)
            //    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //    : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(json);
        }
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SimpleFunction.Function
{
    public class WarmUp
    {
        private readonly IConfiguration _configuration;

        public WarmUp(IConfiguration configuration)
        {
            _configuration = configuration;
        } 

        [FunctionName(nameof(WarmUp))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogCritical("Warming up, right now!!");

            await Task.Delay(120000);

            return new OkObjectResult("OK");
        }
    }
}
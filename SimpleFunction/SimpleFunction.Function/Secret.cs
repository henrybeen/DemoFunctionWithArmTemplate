using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SimpleFunction.Function
{
    public class Secret
    {
        private readonly IConfiguration _configuration;

        public Secret(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [FunctionName(nameof(Secret))]
        [Disable("IsDisabled")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var secret = _configuration["Secret"];

            return new OkObjectResult($"Here have a secret: {secret}");
        }
    }
}

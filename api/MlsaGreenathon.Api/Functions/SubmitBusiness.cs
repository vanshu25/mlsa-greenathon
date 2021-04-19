using System;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web.Http;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MlsaGreenathon.Api.Requests;
using MlsaGreenathon.Models;
using Newtonsoft.Json;

namespace MlsaGreenathon.Api.Functions
{
    public static class SubmitBusiness
    {
        [FunctionName("SubmitBusiness")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiRequestBody(MediaTypeNames.Application.Json, typeof(CreateBusinessDto), Required = true)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [Table("Businesses", Connection = Defaults.DefaultStorageConnection)] CloudTable table,
            ILogger log)
        {
            var reader = new StreamReader(req.Body);
            var json = await reader.ReadToEndAsync();

            var request = JsonConvert.DeserializeObject<CreateBusinessDto>(json);

            // Validate
            var validationResult = await new CreateBusinessDto.Validator().ValidateAsync(request);
            if (!validationResult.IsValid)
                return new BadRequestErrorMessageResult(validationResult.ToString());

            // Map
            var entity = Defaults.Mapper.Map<Business>(request);

            // Insert into table
            try
            {
                await table.ExecuteAsync(TableOperation.Insert(entity));
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Table insert operation failed");
                return new InternalServerErrorResult();
            }

            return new OkResult();
        }
    }
}


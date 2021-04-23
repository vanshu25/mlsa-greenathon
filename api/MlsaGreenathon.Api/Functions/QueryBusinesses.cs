using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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

namespace MlsaGreenathon.Api.Functions
{
    public static class QueryBusinesses
    {
        [FunctionName("QueryBusinesses")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "name", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **Name** parameter")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            [Table("Businesses", Connection = Defaults.DefaultStorageConnection)] CloudTable table,
            ILogger log)
        {
            // Bind query from router query
            var query = new QueryBusinessDto();
            query = GetModelFromQueryParameters(req.Query);

            // Create actual query
            var tableQuery = table.CreateQuery<Business>();

            var response = table.CreateQuery<Business>().Execute();

            return new OkObjectResult(response);
        }

        private static QueryBusinessDto GetModelFromQueryParameters(IQueryCollection query)
        {
            var dto = new QueryBusinessDto();

            if (query["take"].FirstOrDefault() is string take)
                dto.Take = Convert.ToInt32(take);

            if (query["skip"].FirstOrDefault() is string skip)
                dto.Skip = Convert.ToInt32(skip);

            if (query["term"].FirstOrDefault() is string term)
                dto.Term = term;

            if (query["isoCountryCode"].FirstOrDefault() is string isoCountryCode)
                dto.IsoCountryCode = isoCountryCode;

            // TODO: Validate query DTO

            return dto;
        }
    }
}


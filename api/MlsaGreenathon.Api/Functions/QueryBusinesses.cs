using System;
using System.Linq;
using System.Net;
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
using MlsaGreenathon.Api.Data;
using MlsaGreenathon.Api.Database;
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
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [Table("Businesses", Connection = Defaults.DefaultStorageConnection)] CloudTable table,
            ILogger log)
        {
            // Bind query from router query
            QueryBusinessParameters query;

            try
            {
                query = GetModelFromQueryParameters(req.Query);
            }
            catch (ValidationException ex)
            {
                return new BadRequestErrorMessageResult(ex.Message);
            }

            // Create actual query
            var repository = new BusinessRepository(table);

            try
            {
                var results = repository.QueryAsync(query);
                return new OkObjectResult(results);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Couldn't retrieve items using query {Query}", query);
                return new InternalServerErrorResult();
            }
        }

        private static QueryBusinessParameters GetModelFromQueryParameters(IQueryCollection query)
        {
            var dto = new QueryBusinessParameters();

            if (query["take"].FirstOrDefault() is string take)
                dto.Take = Convert.ToInt32(take);

            if (query["term"].FirstOrDefault() is string term)
                dto.Term = term;

            if (query["isoCountryCode"].FirstOrDefault() is string isoCountryCode)
                dto.IsoCountryCode = isoCountryCode;

            new QueryBusinessParameters.Validator().ValidateAndThrow(dto);

            return dto;
        }
    }
}


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
using Microsoft.Azure.Storage.Blob;
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
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [Table("Businesses", Connection = Defaults.DefaultStorageConnection)] CloudTable table,
            [Blob("logos/{rand-guid}", FileAccess.Write)] ICloudBlob logoBlob,
            ILogger log)
        {
            if (!req.HasFormContentType)
                return new BadRequestErrorMessageResult("Request must be form-data");

            var request = new CreateBusinessDto
            {
                Name = req.Form["name"],
                Industry = req.Form["industry"],
                MissionStatement = req.Form["missionStatement"],
                AddressLine = req.Form["addressLine"],
                Town = req.Form["town"],
                CountryIsoCode = req.Form["countryIsoCode"],
                ZipCode = req.Form["zipCode"],
                Logo = req.Form.Files.GetFile("logo")
            };


            // Validate
            var validationResult = await new CreateBusinessDto.Validator().ValidateAsync(request);
            if (!validationResult.IsValid)
                return new BadRequestErrorMessageResult(validationResult.ToString());

            // Map
            var entity = Defaults.Mapper.Map<Business>(request);

            // Upload logo to blob
            if (request.Logo != null)
                entity.LogoSource = (await UploadLogoAsync(request.Logo, logoBlob)).ToString();

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

            return new OkResult(); // TODO: Return created at result
        }

        private static async Task<Uri> UploadLogoAsync(IFormFile logo, ICloudBlob logoBlob)
        {
            await using var stream = logo.OpenReadStream();
            logoBlob.Properties.ContentType = logo.ContentType;
            await logoBlob.UploadFromStreamAsync(stream);
            return logoBlob.Uri;
        }
    }
}


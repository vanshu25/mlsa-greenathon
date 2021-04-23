using System.Text.Json.Serialization;
using FluentValidation;

namespace MlsaGreenathon.Api.Requests
{
    public class QueryBusinessParametersDto
    {
        public int Take { get; set; } = 30;

        public string Term { get; set; }

        public string IsoCountryCode { get; set; }

        public class Validator : AbstractValidator<QueryBusinessParametersDto>
        {
            public Validator()
            {
                RuleFor(x => x.Take)
                    .GreaterThan(0)
                    .LessThanOrEqualTo(30);
            }
        }

        public override string ToString() => $"Term: {Term}; Country: {IsoCountryCode}; Take: {Take}";
    }
}
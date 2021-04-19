namespace MlsaGreenathon.Api.Requests
{
    public class QueryBusinessDto
    {
        public int Take { get; set; } = 30;

        public int Skip { get; set; } = 0;

        public string Term { get; set; }

        public string IsoCountryCode { get; set; }
    }
}
using System;

namespace MlsaGreenathon.Models
{
    public class Business : Entity
    {
        public string Name { get; set; }

        public string Industry { get; set; }

        public string LogoSource { get; set; }

        public string MissionStatement { get; set; }

        // Address
        public string AddressLine { get; set; }

        public string Town { get; set; }

        public string ZipCode { get; set; }

        public string CountryIsoCode { get; set; }

        
        public bool IsApproved { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        public Business()
        {
            PartitionKey = "business";
        }
    }
}
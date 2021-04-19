using System;

namespace MlsaGreenathon.Models
{
    public class Business : Entity
    {
        public string Name { get; set; }

        public string AddressLine { get; set; }

        public string Town { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        
        public bool IsApproved { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        public Business()
        {
            PartitionKey = "business";
        }
    }
}
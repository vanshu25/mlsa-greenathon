namespace MlsaGreenathon.Models
{
    public class Business : Entity
    {
        public string Name { get; set; }

        public bool IsApproved { get; set; }

        public override string PartitionKey { get; set; } = "Business";
    }
}
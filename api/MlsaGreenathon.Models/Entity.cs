using System;
using Microsoft.Azure.Cosmos.Table;

namespace MlsaGreenathon.Models
{
    public abstract class Entity : TableEntity
    {
        public string Id => RowKey;

        public new abstract string PartitionKey { get; set; }

        protected Entity()
        {
            RowKey = Guid.NewGuid().ToString();
        }
    }
}

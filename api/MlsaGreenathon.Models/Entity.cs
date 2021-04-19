using System;
using Microsoft.Azure.Cosmos.Table;

namespace MlsaGreenathon.Models
{
    public abstract class Entity : TableEntity
    {
        public string GetId() => RowKey;

        protected Entity()
        {
            RowKey = Guid.NewGuid().ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Cosmos.Table;
using MlsaGreenathon.Api.Data;
using MlsaGreenathon.Api.Requests;
using MlsaGreenathon.Models;

namespace MlsaGreenathon.Api.Database
{
    public class BusinessRepository
    {
        private readonly CloudTable _table;

        public BusinessRepository(CloudTable table)
        {
            _table = table;
        }

        public IReadOnlyCollection<Business> QueryAsync(QueryBusinessParameters parameters)
        {
            var queryable = _table.CreateQuery<Business>()
                .Where(x => x.IsApproved);

            if (!string.IsNullOrEmpty(parameters.IsoCountryCode))
                queryable = queryable.Where(x => x.CountryIsoCode == parameters.IsoCountryCode);

            if (!string.IsNullOrEmpty(parameters.Term))
                queryable = queryable.Where(x => x.Name.Equals(parameters.Term));

            return queryable
                .Take(parameters.Take)
                .ToList();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using BudgetApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BudgetApi.Services
{

    
    public class DepenseServices
    {
        private readonly IMongoCollection<Depense> _depense;

        public DepenseServices(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("DepenseStoreDB"));
            var database = client.GetDatabase("DepenseStoreDB");
            _depense = database.GetCollection<Depense>("Depenses");
        }
    }
}

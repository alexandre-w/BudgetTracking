using System.Collections.Generic;
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
            var client = new MongoClient(config.GetConnectionString("BudgetDB"));
            var database = client.GetDatabase("BudgetDB");
            _depense = database.GetCollection<Depense>("Depenses");

        }

        public List<Depense> GetAll()
        {
            return _depense.Find(depense => true).ToList();
        }

        public Depense GetOne(string id)
        {
            return _depense.Find<Depense>(d => d.Id == id).FirstOrDefault();
        }

        public Depense Create(Depense depense)
        {
            _depense.InsertOne(depense);
            return depense;
        }

        public void Update(string id, Depense depenseIn)
        {
            _depense.ReplaceOne(d => d.Id == id, depenseIn);
        }

        public void Delete(Depense depenseIn)
        {
            _depense.DeleteOne(d => d.Id == depenseIn.Id);
        }

        public void Delete(string id)
        {
            _depense.DeleteOne(d => d.Id == id);
        }
    }
}

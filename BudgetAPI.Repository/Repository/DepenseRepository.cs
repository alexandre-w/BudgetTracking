﻿using BudgetAPI.Repository.Interfaces;
using BudgetAPI.Repository.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace BudgetAPI.Repository.Repository
{
    public class DepenseRepository : IDepenseRepository
    {
        private readonly IMongoCollection<Depense> _depenseCollection;

        public DepenseRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("BudgetDB"));
            var database = client.GetDatabase("BudgetDB");
            _depenseCollection = database.GetCollection<Depense>("Depenses");

        }

        public List<Depense> GetAll()
        {
            return _depenseCollection.Find(new BsonDocument()).ToList();
        }

        public Depense GetOne(string id)
        {
            var filter = Builders<Depense>.Filter.Eq("Id", id);
            return _depenseCollection.Find(filter).First();
        }

        public Depense Create(Depense depense)
        {
            _depenseCollection.InsertOne(depense);
            return depense;
        }

        public void Update(string id, Depense depenseIn)
        {
            _depenseCollection.ReplaceOne(d => d.Id == id, depenseIn);
        }

        public void Delete(Depense depenseIn)
        {
            var filter = Builders<Depense>.Filter.Eq("Id", depenseIn.Id);
            _depenseCollection.DeleteOne(filter);
        }

        public void Delete(string id)
        {
            var filter = Builders<Depense>.Filter.Eq("Id", id);
            _depenseCollection.DeleteOne(filter);
        }
    }
}

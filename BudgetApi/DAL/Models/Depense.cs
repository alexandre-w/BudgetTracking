using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BudgetApi.DAL.Models
{
    public class Depense
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Montant")]
        public double Montant { get; set; }

        [BsonElement("DateDepense")]
        public DateTime DateDepense { get; set; }

        [BsonElement("MoyenPaiement")]
        public string MoyenPaiement { get; set; }

        [BsonElement("ParQui")]
        public string ParQui { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }


    }
}

using System;

namespace BudgetApi.DTO
{
    public class DepenseDTO
    {

        public string Id { get; set; }

        public double Montant { get; set; }

        public DateTime DateDepense { get; set; }

        public string MoyenPaiement { get; set; }

        public string ParQui { get; set; }

        public string Category { get; set; }
    }
}

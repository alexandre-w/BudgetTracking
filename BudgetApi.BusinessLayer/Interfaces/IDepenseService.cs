using BudgetApi.BusinessLayer.Models;
using System.Collections.Generic;

namespace BudgetApi.BusinessLayer.Interfaces
{
    public interface IDepenseService
    {
        List<DepenseBL> GetAll();
        DepenseBL GetOne(string id);
        DepenseBL Create(DepenseBL depense);
        void Update(string id, DepenseBL depenseIn);
        void Delete(DepenseBL depenseIn);
        void Delete(string id);
    }
}

using BudgetApi.DAL.Models;
using System.Collections.Generic;

namespace BudgetApi.DAL.Interfaces
{
    public interface IDepenseRepository
    {
        List<Depense> GetAll();
        Depense GetOne(string id);
        Depense Create(Depense depense);
        void Update(string id, Depense depenseIn);
        void Delete(Depense depenseIn);
        void Delete(string id);

    }
}

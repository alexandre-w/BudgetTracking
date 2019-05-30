using BudgetAPI.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetAPI.Repository.Interfaces
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

using AutoMapper;
using BudgetApi.BusinessLayer.Interfaces;
using BudgetApi.BusinessLayer.Models;
using BudgetAPI.Repository.Interfaces;
using BudgetAPI.Repository.Models;
using System;
using System.Collections.Generic;

namespace BudgetApi.BusinessLayer.Services
{
    public class DepenseService :IDepenseService
    {
        private readonly IDepenseRepository _depenseRepo;
        private readonly IMapper _mapper;

        public DepenseService(IMapper mapper, IDepenseRepository depenseRepo)
        {
            _mapper = mapper;
            _depenseRepo = depenseRepo;
        }
        public DepenseBL Create(DepenseBL depense)
        {
            CheckDepenseData(depense);

            Depense dep = _mapper.Map<Depense>(depense);
            Depense depReturn = _depenseRepo.Create(dep);
            return _mapper.Map<DepenseBL>(depReturn);
        }

        public void Delete(DepenseBL depenseIn)
        {
            Depense dep = _mapper.Map<Depense>(depenseIn);
            _depenseRepo.Delete(dep);
        }

        public void Delete(string id)
        {
            _depenseRepo.Delete(id);
        }

        public List<DepenseBL> GetAll()
        {
            var depList = _depenseRepo.GetAll();
            List<DepenseBL> depBlList = new List<DepenseBL>();
            foreach (var dep in depList)
            {
                depBlList.Add(_mapper.Map<DepenseBL>(dep));
            }
            return depBlList;
        }

        public DepenseBL GetOne(string id)
        {
            var dep = _depenseRepo.GetOne(id);
            return _mapper.Map<DepenseBL>(dep);
        }

        public void Update(string id, DepenseBL depenseIn)
        {
            var dep = _mapper.Map<Depense>(depenseIn);
            _depenseRepo.Update(id, dep);
        }

        private DepenseBL CheckDepenseData(DepenseBL depense)
        {
            if (depense.DateDepense == DateTime.MinValue)
                depense.DateDepense = DateTime.Now;

            if (string.IsNullOrEmpty(depense.MoyenPaiement))
                depense.MoyenPaiement = "CB";

            return depense;
        }
    }
}

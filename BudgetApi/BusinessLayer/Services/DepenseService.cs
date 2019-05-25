using AutoMapper;
using BudgetApi.BusinessLayer.Interfaces;
using BudgetApi.BusinessLayer.Models;
using BudgetApi.DAL.Interfaces;
using BudgetApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BudgetApi.BusinessLayer.Services
{
    public class DepenseService : IDepenseService
    {
        private readonly IDepenseRepository _depenseRepo  ;
        private readonly IMapper _mapper;

        public DepenseService(IMapper mapper, IDepenseRepository depenseRepo)
        {
            _mapper = mapper;
            _depenseRepo = depenseRepo;
        }
        public DepenseBL Create(DepenseBL depense)
        {
            Depense dep = _mapper.Map<Depense>(depense);
            Depense depReturn = _depenseRepo.Create(dep);
            return _mapper.Map<DepenseBL>(depReturn);
        }

        public void Delete(DepenseBL depenseIn)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<DepenseBL> GetAll()
        {
            var depList = _depenseRepo.GetAll();
            List<DepenseBL> depBlList = new List<DepenseBL>();
            foreach(var dep in depList)
            {
                depBlList.Add(_mapper.Map<DepenseBL>(dep));
            }
            return depBlList;
        }

        public DepenseBL GetOne(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, DepenseBL depenseIn)
        {
            throw new NotImplementedException();
        }
    }
}

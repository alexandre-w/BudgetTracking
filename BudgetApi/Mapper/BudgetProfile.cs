using AutoMapper;
using BudgetApi.BusinessLayer.Models;
using BudgetApi.DAL.Models;
using BudgetApi.DTO;

namespace BudgetApi.Mapper
{
    public class BudgetProfile : Profile
    {
        public BudgetProfile()
        {
            CreateMap<DepenseBL, DepenseDTO>();
            CreateMap<DepenseDTO, DepenseBL>();

            CreateMap<DepenseBL, Depense>();
            CreateMap<Depense, DepenseBL>();
        }
    }
}

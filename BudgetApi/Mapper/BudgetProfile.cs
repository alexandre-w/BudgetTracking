using AutoMapper;
using BudgetApi.BusinessLayer.Models;
using BudgetApi.DTO;
using BudgetAPI.Repository.Models;

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

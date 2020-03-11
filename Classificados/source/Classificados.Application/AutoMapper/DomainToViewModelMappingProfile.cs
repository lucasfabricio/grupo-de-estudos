using AutoMapper;
using Classificados.Domain.Models;
using Classificados.Application.ViewModels;

namespace Classificados.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
        }
    }
}

using AutoMapper;
using Classificados.Application.ViewModels;
using Classificados.Domain.Commands;

namespace Classificados.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //Category
            CreateMap<CategoryViewModel, CreateNewCategoryCommand>()
                .ConstructUsing(c => new CreateNewCategoryCommand(c.Name, c.ParentCategoryId));
        }
    }
}

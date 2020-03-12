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
            CreateMap<CategoryViewModel, RegisterCategoryCommand>()
                .ConstructUsing(c => new RegisterCategoryCommand(c.Name, c.ParentCategoryId));

            CreateMap<CategoryViewModel, UpdateCategoryCommand>()
                .ConstructUsing(c => new UpdateCategoryCommand(c.Id, c.Name, c.ParentCategoryId));

            CreateMap<CategoryViewModel, RemoveCategoryCommand>()
                .ConstructUsing(c => new RemoveCategoryCommand(c.Id));
        }
    }
}

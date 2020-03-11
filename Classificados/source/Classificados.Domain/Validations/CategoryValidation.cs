using Classificados.Domain.Commands;
using Classificados.Domain.Configs;
using FluentValidation;

namespace Classificados.Domain.Validations
{
    public abstract class CategoryValidation<T> : AbstractValidator<T> where T : CategoryCommand
    {
        protected void ValidateName()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome não foi informado")
                .Length(CategoryConfig.NAME_MIN_LENGTH, CategoryConfig.NAME_MAX_LENGTH)
                .WithMessage($"O nome deve conter entre {CategoryConfig.NAME_MIN_LENGTH} e {CategoryConfig.NAME_MAX_LENGTH} caracteres");
        }
    }
}

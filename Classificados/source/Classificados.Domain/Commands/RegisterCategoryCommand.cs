using Classificados.Domain.Validations;
using System;

namespace Classificados.Domain.Commands
{
    public class RegisterCategoryCommand : CategoryCommand
    {
        public RegisterCategoryCommand(string name, Guid? parentCategoryId = null)
        {
            Name = name;
            ParentCategoryId = parentCategoryId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

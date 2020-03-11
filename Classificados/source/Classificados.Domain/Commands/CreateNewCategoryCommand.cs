using Classificados.Domain.Validations;
using System;

namespace Classificados.Domain.Commands
{
    public class CreateNewCategoryCommand : CategoryCommand
    {
        public CreateNewCategoryCommand(string name, Guid? parentCategoryId = null)
        {
            Name = name;
            ParentCategoryId = parentCategoryId;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateNewCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

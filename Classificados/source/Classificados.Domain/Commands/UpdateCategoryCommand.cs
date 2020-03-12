using Classificados.Domain.Validations;
using System;

namespace Classificados.Domain.Commands
{
    public class UpdateCategoryCommand : CategoryCommand
    {
        public UpdateCategoryCommand(Guid id, string name, Guid? parentCategoryId = null)
        {
            Id = id;
            Name = name;
            ParentCategoryId = parentCategoryId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

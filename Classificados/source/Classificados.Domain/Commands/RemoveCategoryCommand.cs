using Classificados.Domain.Validations;
using System;

namespace Classificados.Domain.Commands
{
    public class RemoveCategoryCommand : CategoryCommand
    {
        public RemoveCategoryCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

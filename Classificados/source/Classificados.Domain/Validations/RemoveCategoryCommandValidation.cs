using Classificados.Domain.Commands;

namespace Classificados.Domain.Validations
{
    public class RemoveCategoryCommandValidation : CategoryValidation<RemoveCategoryCommand>
    {
        public RemoveCategoryCommandValidation()
        {
            ValidateId();
        }
    }
}

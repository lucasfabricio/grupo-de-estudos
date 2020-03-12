using Classificados.Domain.Commands;

namespace Classificados.Domain.Validations
{
    public class UpdateCategoryCommandValidation : CategoryValidation<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidation()
        {
            ValidateName();
            ValidateId();
        }
    }
}

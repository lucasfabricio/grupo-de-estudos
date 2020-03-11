using Classificados.Domain.Commands;

namespace Classificados.Domain.Validations
{
    public class CreateNewCategoryCommandValidation : CategoryValidation<CreateNewCategoryCommand>
    {
        public CreateNewCategoryCommandValidation()
        {
            ValidateName();
        }
    }
}

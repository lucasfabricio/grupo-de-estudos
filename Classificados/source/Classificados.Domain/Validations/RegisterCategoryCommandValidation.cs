using Classificados.Domain.Commands;

namespace Classificados.Domain.Validations
{
    public class RegisterCategoryCommandValidation : CategoryValidation<RegisterCategoryCommand>
    {
        public RegisterCategoryCommandValidation()
        {
            ValidateName();
        }
    }
}

using Classificados.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Classificados.Application.UseCases.Interfaces
{
    public interface ISearchAdvertisementUseCase
    {
        Task<IEnumerable<Advertisement>> GetByCategoryId(int categoryId);
    }
}

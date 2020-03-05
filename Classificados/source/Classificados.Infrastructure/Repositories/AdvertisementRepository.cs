using System.Collections.Generic;
using System.Threading.Tasks;
using Classificados.Domain.Entities;

namespace Classificados.Infrastructure.Repositories
{
    public class AdvertisementRepository
    {
        public Task<List<Advertisement>> GetByCategory(int categoryId)
        {
            throw new System.NotImplementedException();
        }
    }
}

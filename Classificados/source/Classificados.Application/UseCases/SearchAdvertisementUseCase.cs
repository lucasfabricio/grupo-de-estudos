using Classificados.Application.UseCases.Interfaces;
using Classificados.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Application.UseCases
{
    public class SearchAdvertisementUseCase : ISearchAdvertisementUseCase
    {
        private readonly ILogger<SearchAdvertisementUseCase> _logger;

        public SearchAdvertisementUseCase(ILogger<SearchAdvertisementUseCase> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<Advertisement>> GetByCategoryId(int categoryId)
        {
            _logger.LogInformation("SearchAdvertisementUseCase.GetByCategoryId called.");

            var advertisements = new List<Advertisement>
            {
                new Advertisement {Category_Id = 1, Created = new DateTime(2020, 3, 1), Description = "Lorem Ipsum dolor sit amet qwe", Title = "Consectetur P25" },
                new Advertisement {Category_Id = 2, Created = new DateTime(2020, 1, 2), Description = "Lorem Ipsum dolor sit amet asd", Title = "Consectetur P1D5" },
                new Advertisement {Category_Id = 1, Created = new DateTime(2020, 2, 7), Description = "Lorem Ipsum dolor sit amet zxc", Title = "Consectetur DF" },
                new Advertisement {Category_Id = 1, Created = new DateTime(2020, 3, 12), Description = "Lorem Ipsum dolor sit amet ert", Title = "Consectetur FD5" },
                new Advertisement {Category_Id = 3, Created = new DateTime(2020, 1, 23), Description = "Lorem Ipsum dolor sit amet dfg", Title = "Consectetur DF987" },
                new Advertisement {Category_Id = 3, Created = new DateTime(2020, 1, 18), Description = "Lorem Ipsum dolor sit amet cvb", Title = "Consectetur 9845" }
            };

            return advertisements.Where(a => a.Category_Id == categoryId);
        }
    }
}

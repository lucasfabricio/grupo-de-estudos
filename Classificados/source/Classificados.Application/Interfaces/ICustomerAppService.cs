using Classificados.Application.EventSourcedNormalizers;
using Classificados.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Classificados.Application.Interfaces
{
    public interface ICategoryAppService : IDisposable
    {
        void Register(CategoryViewModel categoryViewModel);
        IEnumerable<CategoryViewModel> GetAll();
        CategoryViewModel GetById(Guid id);
        void Update(CategoryViewModel categoryViewModel);
        void Remove(Guid id);
        IList<CategoryHistoryData> GetAllHistory(Guid id);
    }
}

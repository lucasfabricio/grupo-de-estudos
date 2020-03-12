using AutoMapper;
using AutoMapper.QueryableExtensions;
using Classificados.Application.EventSourcedNormalizers;
using Classificados.Application.Interfaces;
using Classificados.Application.ViewModels;
using Classificados.Domain.Commands;
using Classificados.Domain.Core.Bus;
using Classificados.Domain.Interfaces;
using Classificados.Infrastructure.EntityFramework.Repositories.EventSourcing;
using System;
using System.Collections.Generic;

namespace Classificados.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public CategoryAppService(IMapper mapper,
                                  ICategoryRepository categoryRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            return _categoryRepository.GetAll().ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider);
        }

        public CategoryViewModel GetById(Guid id)
        {
            return _mapper.Map<CategoryViewModel>(_categoryRepository.GetById(id));
        }

        public void Register(CategoryViewModel CategoryViewModel)
        {
            var registerCommand = _mapper.Map<RegisterCategoryCommand>(CategoryViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(CategoryViewModel CategoryViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCategoryCommand>(CategoryViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveCategoryCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<CategoryHistoryData> GetAllHistory(Guid id)
        {
            return CategoryHistory.ToJavaScriptCustomerHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

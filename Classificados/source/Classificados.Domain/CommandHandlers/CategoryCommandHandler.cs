using Classificados.Domain.Commands;
using Classificados.Domain.Core.Bus;
using Classificados.Domain.Core.Notifications;
using Classificados.Domain.Events;
using Classificados.Domain.Interfaces;
using Classificados.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Classificados.Domain.CommandHandlers
{
    public class CategoryCommandHandler : CommandHandler,
        IRequestHandler<RegisterCategoryCommand, bool>,
        IRequestHandler<UpdateCategoryCommand, bool>,
        IRequestHandler<RemoveCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMediatorHandler _bus;

        public CategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _categoryRepository = categoryRepository;
            _bus = bus;
        }

        public Task<bool> Handle(RegisterCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var category = new Category(Guid.NewGuid(), request.Name, request.ParentCategoryId);

            var validations = new List<bool>
            {
                CategoryNotExists(request.MessageType, category.Name),
                ParentCategoryExists(request.MessageType, category.ParentCategoryId)
            };

            if (!validations.All(v => v == true))
                return Task.FromResult(false);

            _categoryRepository.Add(category);

            if (Commit())
                _bus.RaiseEvent(new CategoryRegisteredEvent(category.Id, category.Name, category.ParentCategoryId));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var category = new Category(request.Id, request.Name, request.ParentCategoryId);

            var validations = new List<bool>
            {
                CategoryNotExists(request.MessageType, category.Name, category.Id),
                ParentCategoryExists(request.MessageType, category.ParentCategoryId)
            };

            if (!validations.All(v => true))
                return Task.FromResult(false);

            _categoryRepository.Update(category);

            if (Commit())
                _bus.RaiseEvent(new CategoryRegisteredEvent(category.Id, category.Name, category.ParentCategoryId));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            if (!CategoryHasNoChildren(request.MessageType, request.Id))
                return Task.FromResult(false);

            _categoryRepository.Remove(request.Id);

            if (Commit())
                _bus.RaiseEvent(new CategoryRemovedEvent(request.Id));

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _categoryRepository.Dispose();
        }

        private bool CategoryNotExists(string messageType, string name, Guid? id = null)
        {
            var category = _categoryRepository.GetByName(name);

            var exists = category != null && category.Id != id;

            if (exists)
                _bus.RaiseEvent(new DomainNotification(messageType, $"A categoria '{name}' já existe."));

            return !exists;
        }

        private bool ParentCategoryExists(string messageType, Guid? parentCategoryId)
        {
            if (!parentCategoryId.HasValue)
                return true;

            var exists = parentCategoryId.HasValue && _categoryRepository.GetById(parentCategoryId.Value) != null;

            if (!exists)
                _bus.RaiseEvent(new DomainNotification(messageType, $"A categoria pai informada não existe."));

            return exists;
        }

        private bool CategoryHasNoChildren(string messageType, Guid id)
        {
            var hasChildren = _categoryRepository.GetChildrenCategories(id).Any();

            if (hasChildren)
                _bus.RaiseEvent(new DomainNotification(messageType, $"Esta categoria não pode ser removida porque existem categorias filhas cadastradas."));

            return !hasChildren;
        }
    }
}

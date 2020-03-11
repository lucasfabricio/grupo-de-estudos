using Classificados.Domain.Commands;
using Classificados.Domain.Core.Bus;
using Classificados.Domain.Core.Notifications;
using Classificados.Domain.Events;
using Classificados.Domain.Interfaces;
using Classificados.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Classificados.Domain.CommandHandlers
{
    public class CategoryCommandHandler : CommandHandler,
        IRequestHandler<CreateNewCategoryCommand, bool>
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

        public Task<bool> Handle(CreateNewCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var category = new Category(Guid.NewGuid(), request.Name, request.ParentCategoryId);

            if (_categoryRepository.GetByName(category.Name) != null)
            {
                _bus.RaiseEvent(new DomainNotification(request.MessageType, $"A categoria '{category.Name}' já existe."));
                return Task.FromResult(false);
            }

            _categoryRepository.Add(category);

            if (Commit())
                _bus.RaiseEvent(new CategoryCreatedEvent(category.Id, category.Name, category.ParentCategoryId));

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _categoryRepository.Dispose();
        }
    }
}

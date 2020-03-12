using Classificados.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Classificados.Domain.EventHandlers
{
    public class CategoryEventHandler :
        INotificationHandler<CategoryRegisteredEvent>
    {
        public Task Handle(CategoryRegisteredEvent notification, CancellationToken cancellationToken)
        {
            //send log or email
            return Task.CompletedTask;
        }

        public Task Handle(CategoryUpdatedEvent notification, CancellationToken cancellationToken)
        {
            //send log or email
            return Task.CompletedTask;
        }

        public Task Handle(CategoryRemovedEvent notification, CancellationToken cancellationToken)
        {
            //send log or email
            return Task.CompletedTask;
        }
    }
}

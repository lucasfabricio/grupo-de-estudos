using Classificados.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Classificados.Domain.EventHandlers
{
    public class CategoryEventHandler :
        INotificationHandler<CategoryCreatedEvent>
    {
        public Task Handle(CategoryCreatedEvent notification, CancellationToken cancellationToken)
        {
            //send log or email
            return Task.CompletedTask;
        }
    }
}

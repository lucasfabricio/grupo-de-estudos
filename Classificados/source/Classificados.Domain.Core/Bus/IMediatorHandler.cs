using Classificados.Domain.Core.Commands;
using Classificados.Domain.Core.Events;
using System.Threading.Tasks;

namespace Classificados.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T command) where T : Event;
    }
}

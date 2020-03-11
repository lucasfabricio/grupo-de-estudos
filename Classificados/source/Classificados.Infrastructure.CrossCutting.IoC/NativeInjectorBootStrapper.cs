using Classificados.Application.Interfaces;
using Classificados.Application.Services;
using Classificados.Domain.CommandHandlers;
using Classificados.Domain.Commands;
using Classificados.Domain.Core.Bus;
using Classificados.Domain.Core.Events;
using Classificados.Domain.Core.Notifications;
using Classificados.Domain.EventHandlers;
using Classificados.Domain.Events;
using Classificados.Domain.Interfaces;
using Classificados.Infrastructure.CrossCutting.Bus;
using Classificados.Infrastructure.CrossCutting.Identity.Authorization;
using Classificados.Infrastructure.CrossCutting.Identity.Models;
using Classificados.Infrastructure.EntityFramework.Contexts;
using Classificados.Infrastructure.EntityFramework.EventSourcing;
using Classificados.Infrastructure.EntityFramework.Repositories;
using Classificados.Infrastructure.EntityFramework.Repositories.EventSourcing;
using Classificados.Infrastructure.EntityFramework.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Classificados.Infrastructure.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<ICategoryAppService, CategoryAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CategoryCreatedEvent>, CategoryEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<CreateNewCategoryCommand, bool>, CategoryCommandHandler>();

            // Infra - Data
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ClassificadosContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}

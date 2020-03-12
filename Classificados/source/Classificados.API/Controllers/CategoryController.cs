using Classificados.Application.Interfaces;
using Classificados.Application.ViewModels;
using Classificados.Domain.Core.Bus;
using Classificados.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Classificados.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ApiController
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(
            ICategoryAppService categoryAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _categoryAppService = categoryAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Response(_categoryAppService.GetAll());
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            var categoryViewModel = _categoryAppService.GetById(id);

            return Response(categoryViewModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(categoryViewModel);
            }

            _categoryAppService.Register(categoryViewModel);

            return Response(categoryViewModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody] CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(categoryViewModel);
            }

            _categoryAppService.Update(categoryViewModel);

            return Response(categoryViewModel);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _categoryAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [Route("history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var customerHistoryData = _categoryAppService.GetAllHistory(id);
            return Response(customerHistoryData);
        }
    }
}

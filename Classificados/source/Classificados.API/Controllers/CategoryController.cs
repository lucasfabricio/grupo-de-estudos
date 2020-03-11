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

        // GET: api/Category
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Response(_categoryAppService.GetAll());
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            var categoryViewModel = _categoryAppService.GetById(id);

            return Response(categoryViewModel);
        }

        // POST: api/Category
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

        // PUT: api/Category/5
        [HttpPut("{id}")]
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _categoryAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var customerHistoryData = _categoryAppService.GetAllHistory(id);
            return Response(customerHistoryData);
        }
    }
}

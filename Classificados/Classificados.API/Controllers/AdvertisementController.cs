using System.Collections.Generic;
using System.Threading.Tasks;
using Classificados.Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Classificados.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly ISearchAdvertisementUseCase _searchAdvertisementUseCase;

        public AdvertisementController(ISearchAdvertisementUseCase searchAdvertisementUseCase)
        {
            _searchAdvertisementUseCase = searchAdvertisementUseCase;
        }

        // GET: api/Advertisement
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Advertisement/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var result = await _searchAdvertisementUseCase.GetByCategoryId(categoryId);
            var output = new JsonResult(result);

            return output;
        }

        // POST: api/Advertisement
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Advertisement/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

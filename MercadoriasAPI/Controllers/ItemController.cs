using MercadoriasAPI.Models;
using MercadoriasAPI.Repository;
using MercadoriasAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MercadoriasAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _repository;
        private readonly ILogger _logger;

        public ItemController(ItemRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItens()
        {
            var categories = _repository.GetFullItens();
            return Ok(categories);
        }
    }
}

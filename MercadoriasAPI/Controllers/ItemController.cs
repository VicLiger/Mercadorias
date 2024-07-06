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
            var item = _repository.GetFullItens();
            return Ok(item);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Item>> GetItemById(int id)
        {
            var itemById = _repository.GetItemById(id);

            if(itemById is null)
            {
                _logger.LogWarning($"Item com id = {id} não foi encontrado...");
                return NotFound($"Item com id = {id} não foi encontrado...");
            }

            return Ok(itemById);
        }

        [HttpPost]
        public ActionResult CreateItem(Item item)
        {
            if(item is null)
            {
                _logger.LogWarning("Dados inválidos...");
                return BadRequest("Dados inválidos...");  
            }

            var createdItem = _repository.Creatitem(item);
            return new CreatedAtRouteResult("ObterItem", new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id:int}")]
        public ActionResult AttItem(int id, Item item)
        {
            if(id != item.Id)
            {
                _logger.LogWarning("Dados inválidos...");
                return BadRequest("Dados inválidos....");
            }

            _repository.UpdateItem(item);
            return Ok(item);
        }


        [HttpDelete("{id:int}")]
        public ActionResult DeleteItem(int id)
        {
            var item = _repository.GetItemById(id);

            if(item is null)
            {
                _logger.LogWarning($"O item com o id = {id} não foii encontrado");
                return BadRequest($"O item com o id = {id} não foii encontrado");
            }

            var itemRemove = _repository.DeleteItem(id);
            return Ok(itemRemove);

        }


    }
}

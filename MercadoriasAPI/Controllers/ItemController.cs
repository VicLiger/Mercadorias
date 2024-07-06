using MercadoriasAPI.Models;
using MercadoriasAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MercadoriasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _repository;
        private readonly ILogger<ItemController> _logger;

        public ItemController(IItemRepository repository, ILogger<ItemController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItens()
        {
            var items = _repository.GetFullItens();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItemById(int id)
        {
            var item = _repository.GetItemById(id);

            if (item == null)
            {
                _logger.LogWarning($"Item com id = {id} não foi encontrado...");
                return NotFound($"Item com id = {id} não foi encontrado...");
            }

            return Ok(item);
        }

        [HttpPost]
        public ActionResult<Item> CreateItem(Item item)
        {
            if (item == null)
            {
                _logger.LogWarning("Dados inválidos...");
                return BadRequest("Dados inválidos...");
            }

            var createdItem = _repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItemById), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Item> AttItem(int id, Item item)
        {
            if (id != item.Id)
            {
                _logger.LogWarning("Dados inválidos...");
                return BadRequest("Dados inválidos....");
            }

            _repository.UpdateItem(item);
            return Ok(item);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Item> DeleteItem(int id)
        {
            var item = _repository.GetItemById(id);

            if (item == null)
            {
                _logger.LogWarning($"O item com o id = {id} não foi encontrado");
                return NotFound($"O item com o id = {id} não foi encontrado");
            }

            var deletedItem = _repository.DeleteItem(id);
            return Ok(deletedItem);
        }
    }
}

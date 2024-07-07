using MercadoriasAPI.DTOs;
using MercadoriasAPI.DTOs.Mappings;
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
        private readonly IUnityOfWork _unityOfWork;
        private readonly ILogger<ItemController> _logger;

        public ItemController(IUnityOfWork unityOfWork, ILogger<ItemController> logger)
        {
            _unityOfWork = unityOfWork;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetItens()
        {
            var items = await _unityOfWork.ItemRepository.GetFullItensAsync();
            
            if(items is null)
                return NotFound("Não existe nenhum item na lista");

            

            var itemListDTO = items.ToItemDTOList();

            return Ok(itemListDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetItemById(int id)
        {
            var item = await _unityOfWork.ItemRepository.GetItemByIdAsync(id);

            if (item == null)
            {
                _logger.LogWarning($"Item com id = {id} não foi encontrado...");
                return NotFound($"Item com id = {id} não foi encontrado...");
            } 

            var itemDTO = item.ToItemDTO();

            return Ok(item);
        }

        // Explicação: Recebe um item DTO e transforma em item para usar o método de criar item
        //             depois atribui uma váriavel do item criado e transforma esse item em um itemDTO
        [HttpPost]
        public ActionResult<ItemDTO> CreateItem(ItemDTO itemDTO)
        {
            if (itemDTO == null)
            {
                _logger.LogWarning("Dados inválidos...");
                return BadRequest("Dados inválidos...");
            }

            var item = itemDTO.ToItem();

            var createdItem = _unityOfWork.ItemRepository.CreateItem(item);
            _unityOfWork.Commit();

            var newItemDTO = createdItem.ToItemDTO();


            return CreatedAtAction(nameof(GetItemById), new { id = newItemDTO.Id }, newItemDTO);
        }

        [HttpPut("{id:int}")]
        public ActionResult<ItemDTO> AttItem(int id, ItemDTO itemDTO)
        {
            if (id != itemDTO.Id)
            {
                _logger.LogWarning("Dados inválidos...");
                return BadRequest("Dados inválidos....");
            }

            var item = itemDTO.ToItem();

            var AttItem = _unityOfWork.ItemRepository.UpdateItem(item);
            _unityOfWork.Commit();

            var newItemDTO = AttItem.ToItemDTO();


            return Ok(newItemDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ItemDTO>> DeleteItem(int id)
        {
            var item = await _unityOfWork.ItemRepository.GetItemByIdAsync(id);

            if (item == null)
            {
                _logger.LogWarning($"O item com o id = {id} não foi encontrado");
                return NotFound($"O item com o id = {id} não foi encontrado");
            }

            var deletedItem = _unityOfWork.ItemRepository.DeleteItem(id);
            _unityOfWork.Commit();

            var newItemDTO = deletedItem.ToItemDTO();

            return Ok(newItemDTO);
        }
    }
}

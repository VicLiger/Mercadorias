using Mercadorias.Application.DTOs;
using Mercadorias.Application.InterfacesDTO;
using Mercadorias.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mercadorias.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly ILogger<ItemController> _logger;

        public ItemController(IItemService itemService, ILogger<ItemController> logger)
        {
            _itemService = itemService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetItens()
        {
            var itens = await _itemService.GetItens();
            return Ok(itens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetItemById(int id)
        {
            var item = await _itemService.GetById(id);

            if (item is null)
            {
                return BadRequest("");
            }

            return Ok(item);

        }

        // Explicação: Recebe um item DTO e transforma em item para usar o método de criar item
        //             depois atribui uma váriavel do item criado e transforma esse item em um itemDTO
        [HttpPost]
        public ActionResult<ItemDTO> CreateItem([FromBody] ItemDTO itemDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _itemService.Add(itemDTO);
            return Ok("Item criado com sucesso");
        }

        [HttpPut("{id:int}")]
        public ActionResult<ItemDTO> AttItem(int id, ItemDTO itemDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (id != itemDTO.Id)
            {
                return BadRequest();
            }

            _itemService.Update(itemDTO);
            return Ok(itemDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ItemDTO>> DeleteItem(int id)
        {
            var itemDTO = await _itemService.GetById(id);

            if (itemDTO is null)
            {
                return BadRequest();
            }

            await _itemService.Remove(id);
            return Ok(itemDTO);
        }
    }
}
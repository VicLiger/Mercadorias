using AutoMapper;
using Mercadorias.Application.DTOs;
using Mercadorias.Application.InterfacesDTO;
using Mercadorias.Domain.Entities;
using Mercadorias.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadorias.Application.Services
{
    public class ItemService : IItemService
    {
        private IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDTO>> GetItens()
        {
            var itensEntity = await _itemRepository.GetFullItensAsync();
            return _mapper.Map<IEnumerable<ItemDTO>>(itensEntity);
        }

        public async Task<ItemDTO> GetById(int id)
        {
            var itensEntity = await _itemRepository.GetItemByIdAsync(id);
            return _mapper.Map<ItemDTO>(itensEntity);
        }

        public async Task Add(ItemDTO itemDTO)
        {
            var itensEntity = _mapper.Map<Item>(itemDTO);
            await _itemRepository.CreateItemAsync(itensEntity);
        }

        public async Task Update(ItemDTO itemDTO)
        {
            var itensEntity = _mapper.Map<Item>(itemDTO);
            await _itemRepository.UpdateItemAsync(itensEntity);
        }

        public async Task Remove(int id)
        {
            await _itemRepository.DeleteItemAsync(id);
        }
    }
}

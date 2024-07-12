using Mercadorias.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadorias.Application.InterfacesDTO
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDTO>> GetItens();
        Task<ItemDTO> GetById(int id);
        Task Add(ItemDTO item);
        Task Update(ItemDTO item);
        Task Remove(int id);
    }
}

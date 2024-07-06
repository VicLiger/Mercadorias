using MercadoriasAPI.Models;
using System.Collections.Generic;

namespace MercadoriasAPI.Repository.Interface
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetFullItensAsync();
        Task<Item> GetItemByIdAsync(int id);
        Item CreateItem(Item item);
        Item UpdateItem(Item item);
        Item DeleteItem(int id);
    }
}

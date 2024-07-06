using MercadoriasAPI.Models;
using System.Collections.Generic;

namespace MercadoriasAPI.Repository.Interface
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetFullItens();
        Item GetItemById(int id);
        Item CreateItem(Item item);
        Item UpdateItem(Item item);
        Item DeleteItem(int id);
    }
}

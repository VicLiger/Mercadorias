using MercadoriasAPI.Models;

namespace MercadoriasAPI.Repository.Interface
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetFullItens();
        Item GetItemById(int id);
        Item Creatitem(Item item);
        Item UpdateItem(Item item);
        Item DeleteItem(int id);

    }
}

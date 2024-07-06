using MercadoriasAPI.Context;
using MercadoriasAPI.Models;
using MercadoriasAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MercadoriasAPI.Repository
{
    public class ItemRepository : IItemRepository
    {

        private readonly ItemContext _context;

        public ItemRepository(ItemContext context)
        {
            _context = context;
        }
        public Item Creatitem(Item item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            _context.Itens.Add(item);
            _context.SaveChanges();

            return item;
        }

        public Item DeleteItem(int id)
        {
            var item = _context.Itens.Find(id);

            if (item is null)
                throw new ArgumentNullException(nameof(item));

            _context.Itens.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public IEnumerable<Item> GetFullItens()
        {
            return _context.Itens.ToList();
        }

        public Item GetItemById(int id)
        {
            return _context.Itens.FirstOrDefault(x => x.Id == id);
        }

        public Item UpdateItem(Item item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return item;
        }
    }
}

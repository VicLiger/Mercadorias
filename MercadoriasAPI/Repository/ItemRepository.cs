using MercadoriasAPI.Context;
using MercadoriasAPI.Models;
using MercadoriasAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MercadoriasAPI.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly ItemContext _context;

        public ItemRepository(ItemContext context)
        {
            _context = context;
        }

        public Item CreateItem(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.Itens.Add(item);
            //_context.SaveChanges();

            return item;
        }

        public Item DeleteItem(int id)
        {
            var item = _context.Itens.Find(id);

            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.Itens.Remove(item);
            //_context.SaveChanges();

            return item;
        }

        public async Task<IEnumerable<Item>> GetFullItensAsync()
        {
            return await _context.Itens.ToListAsync();
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _context.Itens.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Item UpdateItem(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.Entry(item).State = EntityState.Modified;
            //_context.SaveChanges();

            return item;
        }
    }
}

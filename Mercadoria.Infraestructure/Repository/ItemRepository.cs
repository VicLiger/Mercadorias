using Mercadoria.Infraestructure.Context;
using Mercadorias.Domain.Entities;
using Mercadorias.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadorias.Infraestructure.Repository
{
    public class ItemRepository : IItemRepository
    {

        private readonly AppDbContext _context;
        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Item> CreateItemAsync(Item item)
        {
            if (item is null)
                return null;

            _context.Itens.Add(item);
            _context.SaveChanges();
            return item;
           
        }

        public async Task<Item> DeleteItemAsync(int id)
        {
            var item = _context.Itens.Find(id);

            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.Itens.Remove(item);
            _context.SaveChanges();

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

        public async Task<Item> UpdateItemAsync(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return item;
        }
    }
}

using MercadoriasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MercadoriasAPI.Context
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options) { }
    
        public DbSet<Item> Itens { get; set; }  
    }
}

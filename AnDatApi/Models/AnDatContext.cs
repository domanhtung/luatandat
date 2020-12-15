using Microsoft.EntityFrameworkCore;

namespace AnDatApi.Models
{
    public class AnDatContext : DbContext
    {
        public AnDatContext (DbContextOptions<AnDatContext> options) : base(options) { }

        public DbSet<AnDatItem> AnDatItems { get; set; }
    }
}
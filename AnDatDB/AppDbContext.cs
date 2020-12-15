using Microsoft.EntityFrameworkCore;

namespace AnDatDB
{
    public class AppDbContext : DbContext
    {
        public DbSet<AnDat> AnDat { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=MAYTINH-M1LPUN9\\SQLEXPRESS;Database=AnDat;Intergrated Security=sspi");
        }
    }
}
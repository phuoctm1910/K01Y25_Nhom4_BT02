using Microsoft.EntityFrameworkCore;

namespace K01Y25_Nhom4_BT02.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}

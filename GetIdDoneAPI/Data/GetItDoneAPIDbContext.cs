using GetIdDoneAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GetIdDoneAPI.Data
{
    public class GetItDoneAPIDbContext : DbContext
    {
        public GetItDoneAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Models.Task> Tasks { get; set; }
    }
}

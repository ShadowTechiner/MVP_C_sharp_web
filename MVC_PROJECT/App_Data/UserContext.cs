using Microsoft.EntityFrameworkCore;
using MVC_PROJECT.Models;

namespace MVC_PROJECT.App_Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; } = default!;
        public UserContext(DbContextOptions options) : base(options)
        {

        }
    }
}

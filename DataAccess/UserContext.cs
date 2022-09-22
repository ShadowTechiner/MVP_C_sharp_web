using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess
{
    internal class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; } = default!;
        public UserContext(DbContextOptions options) : base(options)
        {
            
        }

    }
}

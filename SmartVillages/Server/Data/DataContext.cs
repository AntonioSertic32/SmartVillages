using Microsoft.EntityFrameworkCore;
using SmartVillages.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartVillages.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }

    }
}

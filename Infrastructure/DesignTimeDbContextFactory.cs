using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Contexts;

namespace Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<EFDBContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlite(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}

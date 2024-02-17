using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using exemple_project.Models;

namespace exemple_project.Data
{
    public class exemple_projectContext : DbContext
    {
        public exemple_projectContext (DbContextOptions<exemple_projectContext> options)
            : base(options)
        {
        }

        public DbSet<exemple_project.Models.Exemple> Exemple { get; set; } = default!;
    }
}

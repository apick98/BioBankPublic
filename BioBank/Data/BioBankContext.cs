using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BioBank.Models;

namespace BioBank.Data
{
    public class BioBankContext : DbContext
    {
        public BioBankContext (DbContextOptions<BioBankContext> options)
            : base(options)
        {
        }

        public DbSet<BioBank.Models.Collection> Collection { get; set; } = default!;
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.DB
{
    public class SSISContext:DbContext
    {
        protected IConfiguration configuration;

        public SSISContext(DbContextOptions<SSISContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            //// unique name within a column
            //model.Entity<Cinema>().HasIndex(tbl => tbl.Name).IsUnique();

            //// composite keys
            //model.Entity<Seat>().HasAlternateKey(tbl =>
            //    new { tbl.ScreeningId, tbl.Row, tbl.Col }
            //);
        }

        public DbSet<User> User { set; get; }
    }
}

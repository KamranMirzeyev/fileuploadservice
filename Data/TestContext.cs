using System;
using Microsoft.EntityFrameworkCore;
using Core;
using Data.Configurations;

namespace Data
{
    public class TestContext:DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FileConfiguration());
        }

        public DbSet<File> Files { get; set; }
    }
}

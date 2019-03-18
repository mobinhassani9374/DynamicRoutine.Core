using System;
using System.Collections.Generic;
using System.Text;
using DynamicRoutine.Core.Data.Mapper;
using DynamicRoutine.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DynamicRoutine.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMapper());
        }
    }
}

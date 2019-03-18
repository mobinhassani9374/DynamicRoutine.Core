using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicRoutine.Core.Data.Mapper;
using DynamicRoutine.Core.Domain.Entities;
using DynamicRoutine.Core.Utility;
using Microsoft.EntityFrameworkCore;

namespace DynamicRoutine.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            this.Users.Where()
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMapper());
        }

        public ServiceResult Save()
        {
            var result = this.SaveChanges();
            if (result > 0) return ServiceResult.Okay();
            return ServiceResult.Error();
        }
        public async Task<ServiceResult> SaveAsync()
        {
            var result = await this.SaveChangesAsync();
            if (result > 0) return ServiceResult.Okay();
            return ServiceResult.Error();
        }
    }
}

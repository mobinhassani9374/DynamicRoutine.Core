using DynamicRoutine.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicRoutine.Core.Data.Mapper
{
    public class UserMapper : BaseMapper<User, int>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.UserName).IsRequired().HasMaxLength(100);

            builder.Property(c => c.Password).IsRequired().HasMaxLength(100);

            builder.Property(c => c.FullName).HasMaxLength(200);
        }
    }
}

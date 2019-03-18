using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicRoutine.Core.Data
{
    public static class DatabaseInitializer
    {
        public static void Init(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(new Domain.Entities.User
                {
                    FullName = "مبین حسنی",
                    IsAdmin = true,
                    Password = "123456",
                    UserName = "admin"
                });
                context.Save();
            }
        }
    }
}

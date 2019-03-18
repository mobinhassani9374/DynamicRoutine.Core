using DynamicRoutine.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicRoutine.Core.Data.Repositories
{
    public class UserRepository : BaseRepository<User, int>
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }

        public User Find(string userName, string password)
        {
            var entity = AsQueryable()
                 .Where(c => c.UserName.Equals(userName) && c.Password.Equals(password))
                 .FirstOrDefault();

            return entity;
        }
    }
}

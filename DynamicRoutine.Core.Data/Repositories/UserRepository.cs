using DynamicRoutine.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicRoutine.Core.Data.Repositories
{
    public class UserRepository : BaseRepository<User, int>
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }
    }
}

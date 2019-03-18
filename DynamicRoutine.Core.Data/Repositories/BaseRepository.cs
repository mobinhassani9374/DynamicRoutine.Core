using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicRoutine.Core.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}

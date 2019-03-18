using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DynamicRoutine.Core.Domain.Entities
{
    public class User : BaseEntity<int>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public bool IsAdmin { get; set; }
    }
}

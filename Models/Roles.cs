using System;
using System.Collections.Generic;

namespace app.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Users = new HashSet<Users>();
        }

        public int RoleId { get; set; }
        public string Role { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}

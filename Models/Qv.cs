using System;
using System.Collections.Generic;
using app.Models;

namespace app.Models
{
    public partial class Qv
    {
        public Qv()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Qv1 { get; set; }
        public int Idnja { get; set; }

        public Njesia IdnjaNavigation { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}

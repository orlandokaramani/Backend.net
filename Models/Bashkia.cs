using System;
using System.Collections.Generic;
using app.Models;

namespace app.Models
{
    public partial class Bashkia
    {
        public Bashkia()
        {
            Njesia = new HashSet<Njesia>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Bashkia1 { get; set; }
        public int? IdQarku { get; set; }

        public Qarku IdQarkuNavigation { get; set; }
        public ICollection<Njesia> Njesia { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}

using System;
using System.Collections.Generic;
using app.Models;

namespace app.Models
{
    public partial class Njesia
    {
        public Njesia()
        {
            Qv = new HashSet<Qv>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Njesia1 { get; set; }
        public int? IdBashkia { get; set; }

        public Bashkia IdBashkiaNavigation { get; set; }
        public ICollection<Qv> Qv { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}

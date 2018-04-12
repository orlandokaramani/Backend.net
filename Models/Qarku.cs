using System;
using System.Collections.Generic;
using app.Models;

namespace app.Models
{
    public partial class Qarku
    {
        public Qarku()
        {
            Bashkia = new HashSet<Bashkia>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Qarku1 { get; set; }

        public ICollection<Bashkia> Bashkia { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}

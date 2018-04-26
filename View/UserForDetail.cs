using System;
using System.Collections.Generic;
using app.Models;

namespace app.View
{
    public class UserForDetail
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Atesi { get; set; }
        public string Mosha { get; set; }
        public string Emer { get; set; }
        public string Gjinia { get; set; }
        public string Interests { get; set; }
        public string Introduction { get; set; }
        public DateTime LastActive { get; set; }
        public string Mbiemer { get; set; }
        public string PhotoUrl { get; set; }
        public string Roli { get; set; }
         public int? IdQarku { get; set; }
         public int? IdBashkia { get; set; }
        public int? IdNjesia { get; set; }
        public int? IdQv { get; set; }
        public string Qarku { get; set; }
        public string Bashkia { get; set; }
        public string Njesia { get; set; }
        public string Qv { get; set; }
        public ICollection<PhotoForDetail> Photos { get; set; }

    }
}
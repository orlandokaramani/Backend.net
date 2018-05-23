using System;
using System.Collections.Generic;

namespace app.Models
{
    public partial class Users
    {
        public Users()
        {
            Photos = new HashSet<Photos>();
        }

        public int Id { get; set; }
        public string Atesi { get; set; }
        public DateTime Datelindja { get; set; }
        public string Emer { get; set; }
        public string Gjinia { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Interests { get; set; }
        public string Introduction { get; set; }
        public DateTime LastActive { get; set; }
        public string Mbiemer { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int? RoleId { get; set; }
        public string Username { get; set; }
        public int? IdQarku { get; set; }
        public int? IdBashkia { get; set; }
        public int? IdNjesia { get; set; }
        public int? IdQv { get; set; }

        public Bashkia IdBashkiaNavigation { get; set; }
        public Njesia IdNjesiaNavigation { get; set; }
        public Qarku IdQarkuNavigation { get; set; }
        public Qv IdQvNavigation { get; set; }
        public Roles Role { get; set; }
        public ICollection<Photos> Photos { get; set; }
    }
}

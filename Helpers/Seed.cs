using System.Collections.Generic;
using System.Text;
using app.Data;
using app.Models;
using Newtonsoft.Json;

namespace app.Helpers
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;

        }
        public void SeedUsers()
        {
            //_context.Users.RemoveRange(_context.Users);
            //_context.SaveChanges();

            //seed users
            var userData = System.IO.File.ReadAllText("Helpers/generated.json");
            var users = JsonConvert.DeserializeObject<List<Users>>(userData);
            foreach (var user in users)
            {
                //create Password hash
                byte[] passwordhash, passwordSalt;
                CreatePasswordHash("password", out passwordhash, out passwordSalt);
                user.PasswordHash = passwordhash;
                user.PasswordSalt = passwordSalt;
                user.Username = user.Username.ToLower();

                _context.Users.Add(user);
            }
            _context.SaveChanges();
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            }
        }
    }
}
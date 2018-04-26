using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Data
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;
        public UsersRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }


        public async Task<Users> GetUser(int id)
        {
            var user = await _context.Users.Include(r => r.Role).Include(p => p.Photos).Include(q => q.IdQarkuNavigation).FirstOrDefaultAsync(u => u.Id == id);
            
            return user;
        }
      

        public async Task<IEnumerable<Users>> GetUsers()
        {
            

           var users = await _context.Users.Include(p => p.Photos).Include(r => r.Role).Include(q => q.IdQarkuNavigation).ToListAsync();

            return users;
        }


        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
      

        public async Task<IEnumerable<Bashkia>> GetBashkite(int id)
        {
            var bashkite = await _context.Bashkia.Include(b => b.Njesia).Where(c => c.IdQarku == id).ToListAsync();
            
            return bashkite;
        }

       public async Task<IEnumerable<Qarku>> GetQarqet()
        {
                 var qarqet = await _context.Qarku.Include(b => b.Bashkia).ToListAsync();
            
            return qarqet;
        }
        
    }
}
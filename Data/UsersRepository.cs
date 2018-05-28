using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Helpers;
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

        public Task<Photos> GetMainPhotoForUser(int userId)
        {
            return _context.Photos.Where(u => u.UserId == userId).FirstOrDefaultAsync(p => p.IsMain);
        }

        public async Task<Photos> GetPhoto(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync (p => p.Id == id);
            return photo;
        }

        public async Task<Users> GetUser(int id)
        {
            var user = await _context.Users.Include(r => r.Role).Include(p => p.Photos).Include(q => q.IdQarkuNavigation).FirstOrDefaultAsync(u => u.Id == id);
            
            return user;
        }
      

        public async Task<PagedList<Users>> GetUsers(UserParams userParams)
        {
            

           var users = _context.Users.Include(p => p.Photos).Include(r => r.Role).Include(q => q.IdQarkuNavigation);
           
           /* .AsQueryable();

           users = users.Where(u => u.Id != userParams.UserId);
           users = users.Where(u => u.Gjinia == userParams.Gjinia); */

            return await PagedList<Users>.CreateAsync(users, userParams.PageNumber, userParams.pageSize);
        }

       
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
      

        
       
        
    }
}
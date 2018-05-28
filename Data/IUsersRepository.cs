using System.Collections.Generic;
using System.Threading.Tasks;
using app.Helpers;
using app.Models;

namespace app.Data
{
    public interface IUsersRepository
    {
        void Add<T>(T entity) where T: class;

        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<PagedList<Users>> GetUsers(UserParams userParams); 
        Task<Users> GetUser(int id);
        Task<Photos> GetPhoto(int id);
        Task<Photos> GetMainPhotoForUser(int id );
        
    }
}
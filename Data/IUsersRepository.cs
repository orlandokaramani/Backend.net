using System.Collections.Generic;
using System.Threading.Tasks;
using app.Models;

namespace app.Data
{
    public interface IUsersRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<Users>> GetUsers();
        Task<Users> GetUser(int id);
    }
}
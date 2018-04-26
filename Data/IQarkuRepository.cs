using System.Collections.Generic;
using System.Threading.Tasks;
using app.Models;

namespace app.Data
{
    public interface IQarkuRepository
    {
         Task<IEnumerable<Qv>> GetQv();
    }
}
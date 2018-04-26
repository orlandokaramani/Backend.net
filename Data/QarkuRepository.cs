using System.Collections.Generic;
using System.Threading.Tasks;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Data
{
    public class QarkuRepository : IQarkuRepository
    {
        private readonly DataContext _context;

        public QarkuRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Qv>> GetQv()
        {
            var qv = await _context.Qv.ToListAsync();
            return qv;
        }
    }
}
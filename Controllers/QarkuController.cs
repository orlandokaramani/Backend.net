using System.Collections.Generic;
using System.Threading.Tasks;
using app.Data;
using app.View;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [Route("api/[controller]")]
    public class QarkuController : Controller
    {
        private readonly IQarkuRepository _repo;
        private readonly IMapper _mapper;

        public QarkuController(IQarkuRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetQv()
        {
            var qv = await _repo.GetQv();
            var qvtoreturn = _mapper.Map<IEnumerable<QvForList>>(qv);
            return Ok(qvtoreturn);
        }
    }
}
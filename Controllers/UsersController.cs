using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using app.Data;
using app.View;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    /* [Authorize(Roles = "1")] */
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersRepository _repo;
        private readonly IMapper _mapper;
        public UsersController(IUsersRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
          
            var users = await _repo.GetUsers();
            var usersToReturn = _mapper.Map<IEnumerable<UserForList>>(users);
            return Ok(usersToReturn);
        }
      
        
        [HttpGet("{id}", Name= "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);
            var userToReturn = _mapper.Map<UserForDetail>(user);

            return Ok(userToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody]UserForUpdate userForUpdate)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);
            var currentuserid = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var userFromRepo = await _repo.GetUser(id);
            if(userFromRepo == null)
            return NotFound($"Could not find user with ID {id}");

            if (currentuserid != userFromRepo.Id)
            return Unauthorized();

            _mapper.Map(userForUpdate, userFromRepo);

            if(await _repo.SaveAll())
            return NoContent();
            throw new Exception($"Updating user with ID {id} found a problem");

        }
    }
}
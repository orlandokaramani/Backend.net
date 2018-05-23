using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Data;
using app.Models;
using Backend.net.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly DataContext _context;

        public ValuesController(DataContext context) {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<Dictionary<string,int>> Get()
        {
            int totalusers = await _context.Users.Distinct().CountAsync();
            int totalemails = await _context.Users.Where(u => u.Email != null).Distinct().CountAsync();
            int totalphones =await _context.Users.Where(u => u.Telefon != null).Distinct().CountAsync();
             var total = new int[] {totalusers, totalphones, totalemails};
            
            Dictionary<string,int> result = new Dictionary<string,int>();
            
            result.Add( "totalusers", totalusers);
            result.Add( "totalemails", totalemails);
            result.Add( "totalphones", totalphones);
            
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

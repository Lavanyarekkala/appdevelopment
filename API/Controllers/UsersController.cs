using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var Users=await _context.Users.ToListAsync();

            return Users;
        }
        //Hits this end point when my route is given as api/Users/1(i.e., here id must be given)//
        [HttpGet("{id}")]
         public  async Task<ActionResult <AppUser>> GetUser(int id)
        {
          return await _context.Users.FindAsync(id);
        }
    }
}
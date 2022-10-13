using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class SCBController : BaseApiController
    {
        private readonly DataContext _context;
        public SCBController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Root>>> GetRoot(){
            return await _context.roots.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Root>> GetRoot(Guid id){
            return await _context.roots.FindAsync(id);
        }
        
        

    }
}
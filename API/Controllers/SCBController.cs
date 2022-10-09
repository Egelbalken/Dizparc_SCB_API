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
        public async Task<ActionResult<List<SCB>>> GetSCB(){
            return await _context.SCBs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SCB>> GetSCB(Guid id){
            return await _context.SCBs.FindAsync(id);
        }

        
    }
}
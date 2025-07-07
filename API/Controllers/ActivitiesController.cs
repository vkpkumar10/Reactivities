using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController(AppDbContext context) : BaseApiController
    {

        // private readonly AppDbContext _context;

        // public ActivitiesController(AppDbContext context)
        // {
        //     _context = context;
        // }


        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            var activities = await context.Activities.ToListAsync();
            return Ok(activities);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(string id)
        {
            var activity = await context.Activities.FindAsync(id);
            if (activity == null) return NotFound();
            return Ok(activity);                                                                                                                                                                                    
        }
    }
        
 
 
}
